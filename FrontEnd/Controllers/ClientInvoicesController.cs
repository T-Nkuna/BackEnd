using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.DTOs;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientInvoicesController : ControllerBase
    {
        private IClientInvoicesService _clientInvoicesService = null;
        public ClientInvoicesController(IClientInvoicesService clientInvoicesService)
        {
            _clientInvoicesService = clientInvoicesService;
        }
        // GET: api/<ClientInvoicesController>
        [HttpGet]
        public IEnumerable<ClientInvoiceDto> Get()
        {
            return new List<ClientInvoiceDto>();
        }

        // GET api/<ClientInvoicesController>/5
        [HttpGet("{id}")]
        public IEnumerable<ClientInvoiceDto> Get(int id)
        {
            return _clientInvoicesService.GetClientInvoices(id);
        }

        // POST api/<ClientInvoicesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientInvoicesController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] ClientInvoiceDto value)
        {
            return _clientInvoicesService.AddClientInvoice(id, value);
        }

        // DELETE api/<ClientInvoicesController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _clientInvoicesService.DeleteClientInvoice(id);
        }
    }
}
