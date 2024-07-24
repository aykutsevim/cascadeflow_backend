using CascadeFlow.Backend.Application.Interfaces;
using CascadeFlow.Backend.Core.Model;

namespace CascadeFlow.Backend.WebApi.Services
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserService userService;

        public WorkItemService(IUnitOfWork unitOfWork, IUserService userService) { 
            this.unitOfWork = unitOfWork;
            this.userService = userService;
        }
        public async Task<IReadOnlyList<WorkItem>> GetAllWorkItemsAsync()
        {
            return await unitOfWork.WorkItems.GetAllAsync();
        }

        public async Task<IReadOnlyList<WorkItem>> GetAllWorkItemsByProjectIdAsync(Guid projectId)
        {
            return await unitOfWork.WorkItems.GetAllByProjectIdAsync(projectId);
        }

        public async Task<IReadOnlyList<WorkItem>> GetTopLevelWorkItemsByProjectIdAsync(Guid projectId)
        {
            return await unitOfWork.WorkItems.GetTopLevelByProjectIdAsync(projectId);
        }

        public async Task<IReadOnlyList<WorkItem>> GetByParentWorkItemIdAsync(Guid parentWorkItemId)
        {
            return await unitOfWork.WorkItems.GetByParentWorkItemIdAsync(parentWorkItemId);
        }

        public async Task<IReadOnlyList<WorkItem>> GetByProjectAndCodeAsync(Guid projectId, int code)
        {
            return await unitOfWork.WorkItems.GetByProjectAndCodeAsync(projectId, code);
        }

        public async Task<IReadOnlyList<WorkItemState>> GetAllWorkItemStatesAsync()
        {
            return await unitOfWork.WorkItemStates.GetAllAsync();
        }

        public async Task<IReadOnlyList<WorkItemType>> GetAllWorkItemTypesAsync()
        {
            return await unitOfWork.WorkItemTypes.GetAllAsync();
        }

    }
}
