using CascadeFlow.Backend.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Application.Interfaces
{
    public interface IWorkItemRepository : IGenericRepository<WorkItem>
    {
        Task<IReadOnlyList<WorkItem>> GetAllByProjectIdAsync(Guid projectId);
        Task<IReadOnlyList<WorkItem>> GetTopLevelByProjectIdAsync(Guid projectId);
    }
}
