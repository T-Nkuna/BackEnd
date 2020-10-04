using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using ClientInvoicing.DTOs;
using ClientInvoicing.Models;
using ClientInvoicing.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientInvoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAccountsController : Controller
    {
        private readonly IClientAccountsService _clientAccountsService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
         public ClientAccountsController(IClientAccountsService clientAccountsService,SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _clientAccountsService = clientAccountsService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        
        // GET: api/<ClientAccounts>
        [HttpGet]
        [Authorize]
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
        public async Task<int> Post([FromBody] ClientAccountDto value)
        {
            return  await _clientAccountsService.AddClientAccount(value,Url,Request.Scheme,Request.Host.ToString());
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

        [HttpPost("authenticate")]
        public async Task<int> Authenticate([FromBody] ClientCredentialsDto credentials)
        {
            IdentityUser user = await _userManager.FindByNameAsync(credentials.UserName);
            if (user != null)
            {

                var passwordMatch = await _signInManager.CheckPasswordSignInAsync(user, credentials.Password, false);
               return passwordMatch.Succeeded ? 1 : 0;
            }
            else
            {
                return 0;
            }
            
        }

        [HttpGet("signout")]
        public async Task<int> SignOut()
        {
            await _signInManager.SignOutAsync();
            return 1;
        }

        [HttpGet("verifyemail")]
        public async Task<bool> VerifyEmail(string code,string userid)
        {
           var user = await _userManager.FindByIdAsync(userid);
            IdentityResult result = await _userManager.ConfirmEmailAsync(user, code);
            return result.Succeeded;
        }
    }
}
