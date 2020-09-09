using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class ClientAccount
    {
        public string Name { get; set; } = "Client's Name";
        public string Surname { get; set; } = "Client's Surname";
        public string Email { get; set; } = "Client's Email Address";
        public string ContactNo { get; set; } = "0000000000";
        public int ClientAccountId { get; set; }
        public List<ClientInvoice> ClientInvoices { get; set; }

    }
}
