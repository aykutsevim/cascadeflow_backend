using CascadeFlow.Backend.Core.Model;

namespace CascadeFlow.Backend.WebApi.Services
{
    public interface IUserService
    {
        string GetMyName();
        Task<int> AddAsync(User entity);
        Task<User> GetByNameAsync(string username);
        Task<int> UpdateAsync(User entity);
        Task<IReadOnlyList<User>> GetAllAsync();
    }
}
