using CascadeFlow.Backend.Core.Model;
using Jdenticon.AspNetCore;


namespace CascadeFlow.Backend.WebApi.Services
{
    public interface IProjectService 
    {
        Task<IReadOnlyList<Project>> GetAllProjectsAsync();
        Task<IReadOnlyList<Project>> GetProjectsByTenantIdAsync();
        Task<byte[]> GetProjectIdenticon(Guid projectId);
    }
}
