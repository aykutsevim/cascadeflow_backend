using CascadeFlow.Backend.Core.Model;
using CascadeFlow.Backend.WebApi.DTO;
using CascadeFlow.Backend.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CascadeFlow.Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpGet, Authorize]
        public async Task<ActionResult<IReadOnlyList<UserDto>>> GetAll()
        {
            var users = await userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] UserDto user)
        {
            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Surname = user.Surname,
                Username = user.Username,
            };
            var result = await userService.AddAsync(newUser);
            return Ok(result);
        }
    }
}
