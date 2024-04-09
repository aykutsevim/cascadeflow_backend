using CascadeFlow.Backend.Core.Model;
using CascadeFlow.Backend.Core.Model.DynamicForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Application.Interfaces
{
    public interface IDynamicFormDataRepository
    {
        Task<FormData> GetByIdAsync(Guid formId, Guid entityId);
        Task<IReadOnlyList<FormData>> GetAllAsync(Guid formRef);
        Task<int> AddAsync(Guid formRef, FormData entity);
        Task<int> UpdateAsync(Guid formRef, FormData entity);
        Task<int> DeleteAsync(Guid formRef, int id);
    }
}
