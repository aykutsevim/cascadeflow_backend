
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeFlow.Backend.Core.Model
{
    [Table("workitemstate", Schema = "public")]
    public class WorkItemState
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public int WorkItemTypeRef { get; set; }

        [ForeignKey("WorkItemTypeRef")]
        public required WorkItemType WorkItemType { get; set; }

        public required string WorkItemStateName { get; set; }

    }
}