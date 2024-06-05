using CascadeFlow.Backend.Core.Model;

namespace CascadeFlow.Backend.WebApi.Services
{
    public interface IProjectService 
    {
        Task<IReadOnlyList<Project>> GetAllProjectsAsync();
        Task<IReadOnlyList<Project>> GetProjectsByTenantIdAsync();
    }
}
