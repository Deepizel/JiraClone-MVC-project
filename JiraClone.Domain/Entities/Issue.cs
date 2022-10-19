using System;
using System.Collections.Generic;
using System.Text;

namespace JiraClone.Domain.Entities
{
    public class issue : BaseEntities
    {
        //public string IssueId { get; set; }
        public string Priority { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public User Assignee { get; set; }
        public User reporter { get; set; }
    }
}
