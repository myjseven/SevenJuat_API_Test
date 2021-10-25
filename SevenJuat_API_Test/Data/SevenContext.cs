using Microsoft.EntityFrameworkCore;
using SevenJuat_API_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevenJuat_API_Test.Data
{
    public class SevenContext : DbContext
    {
        public SevenContext(DbContextOptions<SevenContext> options): base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Payment> Payments { get; set; }


    }
}
