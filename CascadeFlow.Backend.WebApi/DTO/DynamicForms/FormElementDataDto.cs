namespace CascadeFlow.Backend.WebApi.DTO.DynamicForms
{
    public class FormElementDataDto
    {
        public Guid Id { get; set; }
        public Guid FormElementRef { get; set; }
        public string Value { get; set; } = string.Empty;
    }
}
