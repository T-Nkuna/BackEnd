using AutoMapper;
using ClientInvoicing.DTOs;
using ClientInvoicing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInvoicing
{
    public class MapperProfile:Profile
    {
        public MapperProfile() : base()
        {
            CreateMap<ClientAccountDto, ClientAccount>();
            CreateMap<ClientAccount, ClientAccountDto>();
            CreateMap<ClientInvoiceDto, ClientInvoice>();
            CreateMap<ClientInvoice,ClientInvoiceDto>();
        }
    }
}
