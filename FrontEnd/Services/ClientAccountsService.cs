using AutoMapper;
using BackEnd.DataAccess;
using BackEnd.DTOs;
using BackEnd.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class ClientAccountsService : IClientAccountsService
    {
        private readonly IMapper _mapper =null;
        private readonly ApplicationDbContext _dbContext = null;
        private readonly UserManager<IdentityUser> _userManager;
        public ClientAccountsService(
            IMapper mapper,
            ApplicationDbContext applicationDbContext,
            UserManager<IdentityUser> userManager
            
           )
        {
            _mapper = mapper;
            _dbContext = applicationDbContext;
            _userManager = userManager;
        }
        public async Task<int> AddClientAccount(ClientAccountDto clientAccountDto)
        {
            ClientAccount cAccount = _mapper.Map<ClientAccount>(clientAccountDto);
            IdentityUser newUser = new IdentityUser { Email = cAccount.Email, UserName = cAccount.Email };
            IdentityResult result = await _userManager.CreateAsync(newUser);
            if (result.Succeeded) //new User created
            {
                //setup password for newly created user and update cAccount record to point to newly created user
                IdentityUser addedUser = await _userManager.FindByEmailAsync(newUser.Email);
                cAccount.User = addedUser; //link account to user
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
       
        Task<int> AddClientAccount(ClientAccountDto clientAccountDto);

      
        int DeleteClientAccount(int clientAccountId);

        int UpdateClientAccount(int clientAccountId,ClientAccountDto clientAccountDto);

        ClientAccountDto GetClientAccount(int clientAccountId);

        List<ClientAccountDto> GetClientAccounts();

    }
}
