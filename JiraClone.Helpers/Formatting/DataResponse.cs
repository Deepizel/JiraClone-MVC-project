using System;
using System.Collections.Generic;
using System.Text;

namespace JiraClone.Helpers.Formatting
{
    public class DataResponse
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string ExceptionErrorMessage { get; set; }
        public Object Data { get; set; }
    }
    public class ProductData
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int SellPrice { get; set; }
        public int CostPrice { get; set; }
    }
    public class SupplierData
    {
        public int SupplierId { get; set; }
        public string ProductName { get; set; }
        public string Company { get; set; }
        public int Email { get; set; }
        public int PhoneNo { get; set; }
    }

    public class RegisterData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
}
