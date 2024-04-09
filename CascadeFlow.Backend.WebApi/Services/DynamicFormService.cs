using AutoMapper;
using CascadeFlow.Backend.Application.Interfaces;
using CascadeFlow.Backend.Core.Model.DynamicForms;
using CascadeFlow.Backend.WebApi.DTO.DynamicForms;

namespace CascadeFlow.Backend.WebApi.Services
{
    public class DynamicFormService : IDynamicFormService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DynamicFormService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<FormDto>> GetAllAsync()
        {
            var result = await unitOfWork.DynamicForms.GetAllAsync();
            return mapper.Map<List<FormDto>>(result);
        }

        public async Task<FormDto> GetByIdAsync(Guid id)
        {
            var result = await unitOfWork.DynamicForms.GetByIdAsync(id);
            return mapper.Map<FormDto>(result);
        }
    }
}
