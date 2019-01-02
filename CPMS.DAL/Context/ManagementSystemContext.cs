using Microsoft.EntityFrameworkCore;
using CPMS.DAL.DTO;

namespace CPMS.DAL.Context
{
    public class ManagementSystemContext : DbContext
    {
        public DbSet<AddressDTO> Addresses { get; set; }
        public DbSet<CustomerDTO> Customers { get; set; }
        public DbSet<DeveloperDTO> Developers { get; set; }
        public DbSet<BillingInfoDTO> BillingInfos { get; set; }
        public DbSet<CommentDTO> Comments { get; set; }
        public DbSet<InvoiceDTO> Invoices { get; set; }
        public DbSet<ProjectDTO> Projects { get; set; }
        public DbSet<TaskDTO> Tasks { get; set; }
        public DbSet<TimeDTO> Times { get; set; }

        public ManagementSystemContext(DbContextOptions connectionString) :
            base(connectionString)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<BillingInfoDTO>()
                .HasOne(c => c.Address);

            base.OnModelCreating(model);
        }
    }
}
