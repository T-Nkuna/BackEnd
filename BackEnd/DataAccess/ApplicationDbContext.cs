using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<ClientAccount> ClientAccounts{ get; set; }
        public DbSet<ClientInvoice> ClientInvoices{ get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
