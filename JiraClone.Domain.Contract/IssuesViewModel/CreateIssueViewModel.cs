using JiraClone.Domain.Contract.UserViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiraClone.Domain.Contract.IssuesViewModel
{
    public class CreateIssueViewModel
    {
        public int UserId { get; set; }
        public string IssueId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public UserViewModel.UserViewModel Assignee { get; set; }
        public UserViewModel.UserViewModel Reporter { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
    }
}
