using AutoMapper;
using CascadeFlow.Backend.Core.Model.DynamicForms;
using CascadeFlow.Backend.WebApi.DTO.DynamicForms;

namespace CascadeFlow.Backend.WebApi.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            /* CreateMap<FormElement, FormElementDto>();
             CreateMap<List<FormElement>, List<FormElementDto>>();
             CreateMap<Form, FormDto>();
             CreateMap<FormElementData, FormElementDataDto>();
             CreateMap<List<FormElementData>, List<FormElementDataDto>>();
             CreateMap<FormData, FormDataDto>();*/
            CreateMap<FormElement, FormElementDto>();
            //CreateMap<List<FormElement>, List<FormElementDto>>();
            CreateMap<Form, FormDto>();
            CreateMap<FormData, FormDataDto>();
            CreateMap<FormElementData, FormElementDataDto>();
        }
    }
}
