using AutoMapper;
using CascadeFlow.Backend.Application.Interfaces;
using CascadeFlow.Backend.WebApi.DTO.DynamicForms;

namespace CascadeFlow.Backend.WebApi.Services
{
    public class DynamicFormDataService : IDynamicFormDataService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DynamicFormDataService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task<FormDataDto> GetByIdAsync(Guid formId, Guid entityId)
        {
            var result = await unitOfWork.DynamicFormsData.GetByIdAsync(formId, entityId);
            return mapper.Map<FormDataDto>(result);
        }
    }
}
