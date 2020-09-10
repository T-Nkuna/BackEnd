using AutoMapper;
using BackEnd.DTOs;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd
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
