using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Core.Model.DynamicForms
{
    public class Form : BaseAuditedEntity
    {
        public string FormTitle { get; set; } = string.Empty;
        public List<FormElement> Elements { get; set; } = new List<FormElement>();
        public string EntityTable { get; set; } = string.Empty;
    }
}
