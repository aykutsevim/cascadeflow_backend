using CascadeFlow.Backend.Application.Interfaces;
using CascadeFlow.Backend.Core.Model;

namespace CascadeFlow.Backend.WebApi.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserService userService;

        public ProjectService(IUnitOfWork unitOfWork, IUserService userService)
        {
            this.unitOfWork = unitOfWork;
            this.userService = userService;
        }

        public async Task<IReadOnlyList<Project>> GetAllProjectsAsync()
        {
            return await unitOfWork.Projects.GetAllAsync();
        }

        public async Task<IReadOnlyList<Project>> GetProjectsByTenantIdAsync()
        {
            var tenantId = userService.GetUserTenant();

            return await unitOfWork.Projects.GetByTenantIdAsync(tenantId);
        }
    }
}
