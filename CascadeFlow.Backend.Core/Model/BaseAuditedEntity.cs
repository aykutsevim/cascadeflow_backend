using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Core.Model
{
    public class BaseAuditedEntity
    {
        public Guid Id { get; set; }
        public Guid CreUser { get; set; }
        public DateTime CreDate { get; set; }
        public Guid ModUser { get; set; }
        public DateTime ModDate { get; set; }
    }
}
