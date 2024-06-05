using CascadeFlow.Backend.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Application.Interfaces
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<IReadOnlyList<Project>> GetByTenantIdAsync(Guid tenantId);
    }
}
