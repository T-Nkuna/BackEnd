using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTOs
{
    public class ClientInvoiceDto
    {
        public int ClientInvoiceId { get; set; }
        public decimal InvoiceOwedAmount { get; set; }
        public decimal InvoiceAmount { get; set; }
        public int ClientAccountId { get; set; }
    }
}
