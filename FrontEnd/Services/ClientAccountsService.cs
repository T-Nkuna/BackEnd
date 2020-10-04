using AutoMapper;
using ClientInvoicing.DataAccess;
using ClientInvoicing.DTOs;
using ClientInvoicing.Models;
using MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NETCore.MailKit.Core;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ClientInvoicing.Services
{
    public class ClientAccountsService : IClientAccountsService
    {
        private readonly IMapper _mapper =null;
        private readonly ApplicationDbContext _dbContext = null;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailService _mailService;

        public ClientAccountsService(
            IMapper mapper,
            ApplicationDbContext applicationDbContext,
            UserManager<IdentityUser> userManager,
            IEmailService mailService,
            SignInManager<IdentityUser> signInManager
           )
        {
            _mapper = mapper;
            _dbContext = applicationDbContext;
            _userManager = userManager;
            _mailService = mailService;
            _signInManager = signInManager;
        }
        public async Task<int> AddClientAccount(ClientAccountDto clientAccountDto,IUrlHelper url,string protocol,string host)
        {
            ClientAccount cAccount = _mapper.Map<ClientAccount>(clientAccountDto);
            IdentityUser newUser = new IdentityUser { Email = cAccount.Email, UserName = cAccount.Email };
            IdentityResult result = await _userManager.CreateAsync(newUser,clientAccountDto.Password);
            if (result.Succeeded) //new User created
            {
                //setup password for newly created user and update cAccount record to point to newly created user
                IdentityUser addedUser = await _userManager.FindByEmailAsync(newUser.Email);
                cAccount.User = addedUser; //link account to user
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(addedUser);
                var link = url.Action(nameof(ClientInvoicing.Controllers.ClientAccountsController.VerifyEmail), "ClientAccounts", new { userId = addedUser.Id, code = token }, protocol, host);
               // await _mailService.SendAsync(newUser.Email,"Email Verification",$"Click <a href='{link}'>Here</a> to verify your Email",true);
                _dbContext.ClientAccounts.Add(cAccount);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
           
            
        }

       
        public int DeleteClientAccount(int clientAccountId)
        {
            ClientAccount cAccount =_dbContext.ClientAccounts.FirstOrDefault(cAcc => cAcc.ClientAccountId == clientAccountId);
            if (cAccount != null)
            {
                _dbContext.Remove(cAccount);
                return _dbContext.SaveChanges();
            } 
            else
            {
                return 0;
            }
            
           
        }

        public ClientAccountDto GetClientAccount(int clientAccountId)
        {
            ClientAccount clientAccount = _dbContext.ClientAccounts.FirstOrDefault(cAcc => cAcc.ClientAccountId == clientAccountId);
            return clientAccount!=null?_mapper.Map<ClientAccountDto>(clientAccount):null;
        }

        public List<ClientAccountDto> GetClientAccounts()
        {
            return _dbContext.ClientAccounts.ToList().Select(cAcc => _mapper.Map<ClientAccountDto>(cAcc)).ToList();
        }

        public int UpdateClientAccount(int clientAccountId,ClientAccountDto clientAccountDto)
        {
            ClientAccount clientAccount = _dbContext.ClientAccounts.FirstOrDefault(clientAcc => clientAcc.ClientAccountId == clientAccountId);
            if (clientAccount != null)
            {
                clientAccount.Name = clientAccountDto.Name;
                clientAccount.ContactNo = clientAccountDto.ContactNo;
                clientAccount.Email = clientAccountDto.Email;
                return _dbContext.SaveChanges();
            }
            else
            {
                return 0;
            }
           
          
        }

    }

    public interface IClientAccountsService
    {
       
        Task<int> AddClientAccount(ClientAccountDto clientAccountDto,IUrlHelper url,string protocol,string host);

      
        int DeleteClientAccount(int clientAccountId);

        int UpdateClientAccount(int clientAccountId,ClientAccountDto clientAccountDto);

        ClientAccountDto GetClientAccount(int clientAccountId);

        List<ClientAccountDto> GetClientAccounts();

    }
}
