using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Core.Model
{
    public class Project
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public Guid TenantRef { get; set; }
        public Guid IdenticonHashable { get; set; }
    }
}
