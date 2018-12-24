using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CPMS.DAL.DAO;

namespace CPMS.DAL.Context
{
    public class ManagementSystemContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<BillingInfo> BillingInfos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Time> Times { get; set; }

        public ManagementSystemContext(DbContextOptions connectionString) :
            base(connectionString)
        {
        }
     }
}
