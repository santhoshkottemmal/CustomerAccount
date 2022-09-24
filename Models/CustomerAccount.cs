using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerAccount.Models
{
    public class CustomerAccount
    {
        public int AccountId { get; set; }
        public int? CustomerId { get; set; }
        public string AccountType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Narration { get; set; }
        public int? ChequeNo { get; set; }
        public DateTime? ValueDate { get; set; }
        public int? Withdrawal { get; set; }
        public int? Deposit { get; set; }
        public int? ClosingBalance { get; set; }
    }
}
