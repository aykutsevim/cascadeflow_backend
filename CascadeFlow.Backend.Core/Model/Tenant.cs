using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Core.Model
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string TenantName { get; set; } = string.Empty;
    }
}
