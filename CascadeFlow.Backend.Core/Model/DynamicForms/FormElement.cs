using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Core.Model.DynamicForms
{
    public class FormElement : BaseAuditedEntity
    {
        public string DtypeString { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string FieldName { get; set; } = string.Empty;
        public String? ListItems { get; set; }
    }
}
