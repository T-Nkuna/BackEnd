using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class ClientInvoice
    {
        public int ClientInvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public bool InvoicePaid { get; set; } = false;
        public decimal InvoiceAmount { get; set; } = 0.00M;
        public decimal InvoiceOwedAmount { get; set; } = 0.00M;
        public decimal InvoiceLasPaidAmount { get; set; } = 0.00M;
        public DateTime? InvoiceLastPaidOn { get; set; } = null;
        public int ClientAccountId { get; set; }
        public ClientAccount ClientAccount{get;set;}
    }
}
