using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.DTOs;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAccountsController : ControllerBase
    {
        private readonly IClientAccountsService _clientAccountsService;
         public ClientAccountsController(IClientAccountsService clientAccountsService)
        {
            _clientAccountsService = clientAccountsService;
        }
        
        // GET: api/<ClientAccounts>
        [HttpGet]
        public IEnumerable<ClientAccountDto> Get()
        {
            return _clientAccountsService.GetClientAccounts();
        }

        // GET api/<ClientAccounts>/5
        [HttpGet("{id}")]
        public ClientAccountDto Get(int id)
        {
            return _clientAccountsService.GetClientAccount(id);
        }

        // POST api/<ClientAccounts>
        [HttpPost]
        public int Post([FromBody] ClientAccountDto value)
        {
            return _clientAccountsService.AddClientAccount(value);
        }

        // PUT api/<ClientAccounts>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] ClientAccountDto value)
        {
            return _clientAccountsService.UpdateClientAccount(id,value);
        }

        // DELETE api/<ClientAccounts>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
           return _clientAccountsService.DeleteClientAccount(id);
        }
    }
}
