using CascadeFlow.Backend.Application.Interfaces;
using CascadeFlow.Backend.Core.Model;

namespace CascadeFlow.Backend.WebApi.Services
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IUnitOfWork unitOfWork;
        public WorkItemService(IUnitOfWork unitOfWork) { 
            this.unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<WorkItem>> GetAllWorkItemsAsync()
        {
            return await unitOfWork.WorkItems.GetAllAsync();
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
