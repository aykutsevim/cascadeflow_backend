using CascadeFlow.Backend.Core.Model.DynamicForms;

namespace CascadeFlow.Backend.WebApi.DTO.DynamicForms
{
    public class FormDto
    {
        public Guid Id { get; set; }
        public string FormTitle { get; set; } = string.Empty;
        public List<FormElementDto> Elements { get; set; } = new List<FormElementDto>();
    }
}
