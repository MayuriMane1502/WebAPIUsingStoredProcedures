using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Customer
    {
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string AcctType { get; set; }
        public string AcctNo { get; set; }
        public string City { get; set; }
    }
}