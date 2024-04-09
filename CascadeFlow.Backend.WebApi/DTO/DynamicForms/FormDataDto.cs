namespace CascadeFlow.Backend.WebApi.DTO.DynamicForms
{
    public class FormDataDto
    {
        public Guid Id { get; set; }
        public Guid FormRef { get; set; }
        public List<FormElementDataDto> Elements { get; set; } = new List<FormElementDataDto>();
        public List<string> Errors { get; set; } = new List<string> { };
    }
}
