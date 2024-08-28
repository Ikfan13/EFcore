using Microsoft.EntityFrameworkCore;

namespace EFCRUDDemo.Models
{
    public class CompanyContext : DbContext
    {

        public CompanyContext(DbContextOptions<CompanyContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(d => d.department)
                .WithMany(propa => propa.Employees)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_emp_dept");
            });
        }


        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }





    }
}
