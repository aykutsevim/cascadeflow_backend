using CascadeFlow.Backend.Core.Model.DynamicForms;
using CascadeFlow.Backend.WebApi.DTO.DynamicForms;

namespace CascadeFlow.Backend.WebApi.Services
{
    public interface IDynamicFormService
    {
        Task<IReadOnlyList<FormDto>> GetAllAsync();
        Task<FormDto> GetByIdAsync(Guid id);

    }
}
