using CascadeFlow.Backend.WebApi.DTO;
using CascadeFlow.Backend.Core.Model;
using CascadeFlow.Backend.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace CascadeFlow.Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IUserService userService;

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            this.configuration = configuration;
            this.userService = userService;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var userName = userService.GetMyName();
            return Ok(userName);
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(AuthDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User();

            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await userService.AddAsync(user);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResultDto>> Login(AuthDto request)
        {
            User user = await userService.GetByNameAsync(request.Username);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken.Token;
            user.RefreshTokenCreatedAt = refreshToken.CreatedAt;
            user.RefreshTokenExpiresAt = refreshToken.ExpiresAt;
            
            SetRefreshToken(refreshToken);

            await userService.UpdateAsync(user);

            var result = new LoginResultDto {
                Username = user.Username,
                Token = token ,
                AvatarHashable = user.AvatarHashable.ToString()
            };

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken(string userName)
        {
            var refreshToken = Request.Cookies["refreshToken"];

            User user = await userService.GetByNameAsync(userName);

            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.RefreshTokenExpiresAt < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            user.RefreshToken = newRefreshToken.Token;
            user.RefreshTokenCreatedAt = newRefreshToken.CreatedAt;
            user.RefreshTokenExpiresAt = newRefreshToken.ExpiresAt;

            await userService.UpdateAsync(user);

            SetRefreshToken(newRefreshToken);

            return Ok(token);
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                ExpiresAt = DateTime.Now.AddDays(7),
                CreatedAt = DateTime.Now
            };

            return refreshToken;
        }

        private string CreateToken(User user)
        {
            var section = configuration.GetSection("AppSettings:Token");

            if (section == null || section.Value == null)
            {
                return "";

            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.GroupSid, user.TenantRef.ToString())
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(section.Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


        private void SetRefreshToken(RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.ExpiresAt
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
