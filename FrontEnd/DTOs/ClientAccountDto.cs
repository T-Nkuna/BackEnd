﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInvoicing.DTOs
{
    public class ClientAccountDto
    {
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int ClientAccountId { get; set; }

        public string Password { get; set; }

    }
}
