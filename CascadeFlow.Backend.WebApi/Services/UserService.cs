using CascadeFlow.Backend.Application.Interfaces;
using CascadeFlow.Backend.Core.Model;
using System.Security.Claims;

namespace CascadeFlow.Backend.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetMyName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }

        public Guid GetUserTenant()
        {
            Guid result = Guid.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.GroupSid) ?? String.Empty);
            }
            return result;
        }


        public async Task<int> AddAsync(User entity)
        {
            return await unitOfWork.Users.AddAsync(entity);
        }

        public async Task<User> GetByNameAsync(string username)
        {
            return await unitOfWork.Users.GetByNameAsync(username);
        }

        public async Task<int> UpdateAsync(User entity)
        {
            return await unitOfWork.Users.UpdateAsync(entity);
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            return await unitOfWork.Users.GetAllAsync();
        }


    }
}
