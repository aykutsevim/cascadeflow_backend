using CascadeFlow.Backend.Application.Interfaces;
using CascadeFlow.Backend.Core.Model;
using Jdenticon;
using Jdenticon.AspNetCore;


namespace CascadeFlow.Backend.WebApi.Services
{
    public class ProjectService : IProjectService
    {
        const int DEFAULT_IDENTICON_SIZE = 100;

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

        public async Task<byte[]> GetProjectIdenticon(Guid projectId)
        {
            var project = await unitOfWork.Projects.GetByIdAsync(projectId);

            // Generate an identicon as a PNG image
            var stream = new MemoryStream();
            Jdenticon.Identicon
                .FromValue(project.IdenticonHashable.ToString(), size: 100) // Use the id as the value and set the size of the identicon
                .SaveAsSvg(stream);
            stream.Position = 0; // Reset the stream position to the beginning

            // Return the image stream as a File result
            return stream.ToArray();
        }
    }
}
