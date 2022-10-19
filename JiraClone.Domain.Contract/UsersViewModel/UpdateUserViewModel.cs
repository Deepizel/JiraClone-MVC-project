﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JiraClone.Domain.Contract.UserViewModel
{
    public class UpdateUserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Password { get; set; }
    }
}
