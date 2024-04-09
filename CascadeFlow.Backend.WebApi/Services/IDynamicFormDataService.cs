using CascadeFlow.Backend.WebApi.DTO.DynamicForms;

namespace CascadeFlow.Backend.WebApi.Services
{
    public interface IDynamicFormDataService
    {
        Task<FormDataDto> GetByIdAsync(Guid formId, Guid entityId);
    }
}
