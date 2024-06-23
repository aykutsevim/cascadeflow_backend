using CascadeFlow.Backend.Core.Model;

namespace CascadeFlow.Backend.WebApi.Services
{
    public interface IWorkItemService
    {
        Task<IReadOnlyList<WorkItemState>> GetAllWorkItemStatesAsync();
        Task<IReadOnlyList<WorkItemType>> GetAllWorkItemTypesAsync();
        Task<IReadOnlyList<WorkItem>> GetAllWorkItemsAsync();
        Task<IReadOnlyList<WorkItem>> GetAllWorkItemsByProjectIdAsync(Guid projectId);
        Task<IReadOnlyList<WorkItem>> GetTopLevelWorkItemsByProjectIdAsync(Guid projectId);
    }
}
