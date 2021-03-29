using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
   public class PandoraContext:DbContext
    {
        public PandoraContext(DbContextOptions<PandoraContext> options) : base(options)
        {
        }
        public DbSet<Employees> Employeeses{ get; set; }
        public DbSet<Job> Jobs{ get; set; }
        public DbSet<EmployeesJob> EmployeesJobs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeesJob>().HasKey(i => new
            {
                i.EmployeesId,
                i.JobsId
            });
            
        }
    }
}
