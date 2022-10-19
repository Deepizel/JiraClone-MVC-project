using System;
using System.Collections.Generic;
using System.Text;

namespace JiraClone.Domain.Contract.UsersViewModel
{
    public class LoginUserViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
