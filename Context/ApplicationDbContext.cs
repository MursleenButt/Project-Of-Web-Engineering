using KarigarBotiqueStore.Model;
using Microsoft.EntityFrameworkCore;
using KarigarBotiqueStore.Data;
using KarigarBotiqueStore.Model;
using System.Collections.Generic;

namespace KarigarBotiqueStore.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }


}
