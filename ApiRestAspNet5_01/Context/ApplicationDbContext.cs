using ApiRestAspNet5_01.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiRestAspNet5_01.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasKey(i => i.Id);
            modelBuilder.Entity<Person>().Property(i => i.FirstName).IsRequired();
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Person>().Property(i => i.FirstName).HasColumnName("First Name");
            modelBuilder.Entity<Person>().Property(i => i.LastName).HasColumnName("Last Name");
        }
    }
}
