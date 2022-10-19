﻿using JiraClone.Domain.Contract.UsersViewModel;
using JiraClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiraClone.Domain.Contract.IssuesViewModel
{
   public class IssuesViewModel
    {
        public int IssueId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public UserViewModel Assignee { get; set; }
        public UserViewModel Reporter { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public string Message { get; set; }
    }
}
