using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeFlow.Backend.Core.Model
{
    [Table("work_item_type", Schema = "public")]
    public class WorkItemType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("process_ref")]
        [Required]
        public int ProcessRef { get; set; }

        [Column("work_item_type_name")]
        public required string WorkItemTypeName { get; set; }
    }
}