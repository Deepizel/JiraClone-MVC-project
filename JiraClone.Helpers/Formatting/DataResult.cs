using System;
using System.Collections.Generic;
using System.Text;

namespace JiraClone.Helpers.Formatting
{
    public class DataResult
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string ExceptionErrorMessage { get; set; }
        public Object Data { get; set; }
    }
}
