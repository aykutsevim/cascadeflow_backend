namespace CascadeFlow.Backend.WebApi.DTO.DynamicForms
{
    public class FormElementDto
    {
        public Guid Id { get; set; }
        public string DtypeString { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string FieldName { get; set; } = string.Empty;
        public String? ListItems { get; set; }
    }
}
