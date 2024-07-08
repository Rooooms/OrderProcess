using Microsoft.EntityFrameworkCore;
using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderEntities> Orders { get; set; }

        public DbSet<categorygroup> CategoryGroups { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Products>RamProduct {  get; set; }

        public DbSet<DealCodes> DealCodes { get; set; }

        public DbSet<DealCustomerScope> DealCodeCustomerScope { get; set; }

        public DbSet<DealProductScope> ProductScope { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Salesman>().HasNoKey();
            modelBuilder.Entity<Salesman>().ToView("salesman");
            modelBuilder.Entity<DealcodeMaster>().HasNoKey();
            modelBuilder.Entity<DealcodeMaster>().ToView("dealtype");
        }
    }
}
