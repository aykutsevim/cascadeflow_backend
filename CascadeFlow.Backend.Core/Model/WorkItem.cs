using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeFlow.Backend.Core.Model // Replace "YourNamespace" with your desired namespace
{
    [Table("work_item", Schema = "public")] // Table name annotation
    public class WorkItem
    {
        [Key] // Primary Key annotation
        public Guid Id { get; set; }

        [Required] // Not null annotation
        [Column("work_item_type_ref")] // Column name annotation
        public int WorkItemTypeRef { get; set; }

        [Required] // Not null annotation
        [Column("work_item_state_ref")] // Column name annotation
        public int WorkItemStateRef { get; set; }

        [Column("assignee")] // Column name annotation
        public Guid? Assignee { get; set; }

        [Column("title")] // Column name annotation
        public string Title { get; set; }

        [Column("description")] // Column name annotation
        public string Description { get; set; }

        [Column("priority")] // Column name annotation
        public int Priority { get; set; }
    }
}