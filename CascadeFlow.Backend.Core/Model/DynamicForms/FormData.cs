using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Core.Model.DynamicForms
{
    public class FormData
    {
        public Guid FormRef { get; set; }
        public List<FormElementData> Elements { get; set; } = new List<FormElementData>();

        public List<string> Errors { get; set; } = new List<string> { };

    }
}
