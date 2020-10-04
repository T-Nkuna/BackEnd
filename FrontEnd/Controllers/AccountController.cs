using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientInvoicing.DTOs;
using IdentityServer3.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;

namespace FrontEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost("login")]
        public async Task<int> Login([FromBody] ClientCredentialsDto credentials)
        {
            IdentityUser user = await _userManager.FindByNameAsync(credentials.UserName);
            if (user != null)
            {

                var passwordMatch =  await _signInManager.PasswordSignInAsync(user,credentials.Password,false,false);

                return passwordMatch.Succeeded? 1 : 0;
            }
            else
            {
                return 0;
            }
           
        }

        [HttpGet("login")]
        public Task Login(string returnUrl)
        {
           
            if (!string.IsNullOrEmpty(returnUrl) && Request.Cookies.ContainsKey("Identity.Auth.Cookie"))
            {
              Response.Redirect(returnUrl);
            }
            return Task.CompletedTask;
        }

        [HttpGet("signout")]
        public async Task<int> SignOut()
        {
          await  _signInManager.SignOutAsync();
            return 1;
        }
    }


}
