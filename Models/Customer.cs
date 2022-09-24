using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerAccount.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime? CustomerDob { get; set; }
        public string CustomerPan { get; set; }
    }
}
