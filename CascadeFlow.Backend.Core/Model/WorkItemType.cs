using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeFlow.Backend.Core.Model
{
    [Table("workitemtype", Schema = "public")]
    public class WorkItemType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        public int ProcessRef { get; set; }

        public required string WorkItemTypeName { get; set; }
    }
}