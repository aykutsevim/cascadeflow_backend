using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace CascadeFlow.Backend.Core.Model // Replace "YourNamespace" with your desired namespace
{
    [Table("workitem", Schema = "public")] // Table name annotation
    public class WorkItem
    {
        [Key] // Primary Key annotation
        public Guid Id { get; set; }

        public int WorkItemTypeRef { get; set; }
        public required string WorkItemTypeName { get; set; }
        public int WorkItemStateRef { get; set; }
        public required string WorkItemStateName { get; set; }
        public Guid? Assignee { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int Priority { get; set; }
        public Guid ProjectRef { get; set; }
        public Guid WorkItemRef { get; set; }
        public int Code { get; set; }
    }
}