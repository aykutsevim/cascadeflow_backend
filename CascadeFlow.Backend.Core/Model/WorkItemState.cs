
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeFlow.Backend.Core.Model
{
    [Table("work_item_state", Schema = "public")]
    public class WorkItemState
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("work_item_type_ref")]
        public int WorkItemTypeRef { get; set; }

        [ForeignKey("WorkItemTypeRef")]
        public WorkItemType WorkItemType { get; set; }

        [Column("work_item_state_name")]
        public string WorkItemStateName { get; set; }
    }
}