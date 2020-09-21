using BackEnd.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DataAccess
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public DbSet<ClientAccount> ClientAccounts{ get; set; }
        public DbSet<ClientInvoice> ClientInvoices{ get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
