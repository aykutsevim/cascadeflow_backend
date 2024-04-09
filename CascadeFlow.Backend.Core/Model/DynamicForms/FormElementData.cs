using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Core.Model.DynamicForms
{
    public class FormElementData
    {
        public Guid FormElementRef  { get; set; }
        public string FieldName { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

    }
}
