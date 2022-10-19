using System;
using System.Collections.Generic;
using System.Text;

namespace JiraClone.Domain.Entities
{
    public class User : BaseEntities
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
    }
}
