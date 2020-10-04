using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClientInvoicing.DataAccess;
using ClientInvoicing.DTOs;
using ClientInvoicing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace ClientInvoicing.Services
{
    public class ClientInvoicesService:IClientInvoicesService
    {
        private readonly ApplicationDbContext _dbContext =null;
        private readonly IMapper _mapper = null;
         public ClientInvoicesService(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int AddClientInvoice(int clientAccountId, ClientInvoiceDto clientInvoiceDto)
        {
            ClientAccount clientAcc = _dbContext.ClientAccounts.FirstOrDefault(cAcc => cAcc.ClientAccountId == clientAccountId);
            if (clientAcc != null)
            {
                ClientInvoice cInvoice = (_mapper.Map<ClientInvoice>(clientInvoiceDto));
                cInvoice.ClientAccountId = clientAcc.ClientAccountId;
                _dbContext.Add(cInvoice);
                return _dbContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public int DeleteClientInvoice(int invoiceId)
        {
            ClientInvoice clientInvoice = _dbContext.ClientInvoices.FirstOrDefault(clientInv => clientInv.ClientInvoiceId == invoiceId);
            if (clientInvoice != null)
            {
                _dbContext.Remove(clientInvoice);
               return _dbContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public List<ClientInvoiceDto> GetClientInvoices(int clientAccountId)
        {
            return _dbContext.ClientInvoices.Where(cInv=>cInv.ClientAccountId==clientAccountId ).ToList().Select(cAcc=> _mapper.Map<ClientInvoiceDto>(cAcc)).ToList();

        }

        public int UpdateClientInvoice(int invoiceId, ClientInvoiceDto clientInvoiceDto)
        {
            ClientInvoice inv = _dbContext.ClientInvoices.FirstOrDefault(inv => inv.ClientInvoiceId == invoiceId);
            if (inv != null)
            {
                inv.InvoiceAmount = clientInvoiceDto.InvoiceAmount;
                inv.InvoiceOwedAmount = clientInvoiceDto.InvoiceOwedAmount;
                return _dbContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }

    public interface IClientInvoicesService
    {
        List<ClientInvoiceDto> GetClientInvoices(int clientAccountId);
        int AddClientInvoice(int clientAccountId, ClientInvoiceDto clientInvoiceDto);

        int UpdateClientInvoice(int invoiceId, ClientInvoiceDto clientInvoiceDto);
        int DeleteClientInvoice(int invoiceId);
    }
}
