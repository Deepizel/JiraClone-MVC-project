using System;
using System.Collections.Generic;
using System.Text;

namespace JiraClone.Helpers.Formatting
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }
    }
}
