using ApiRestAspNet5_01.Model;
using ApiRestAspNet5_01.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRestAspNet5_01.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.FirstName).HasColumnName("First Name");
            modelBuilder.Entity<Person>().Property(p => p.LastName).HasColumnName("Last Name");
            modelBuilder.Entity<Person>().ToTable("Persons");

            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Author).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.LaunchDate).HasColumnName("Launch Date");
            modelBuilder.Entity<Book>().Property(b => b.Price).HasColumnType("decimal(5,2)");
            modelBuilder.Entity<Book>().ToTable("Books");

            modelBuilder.Entity<User>().HasKey(b => b.Id);
            modelBuilder.Entity<User>().Property(b => b.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(b => b.UserName).HasColumnName("User Name");
            modelBuilder.Entity<User>().Property(b => b.Password).IsRequired();
            modelBuilder.Entity<User>().Property(b => b.FullName).HasColumnName("Full Name");
            modelBuilder.Entity<User>().Property(b => b.RefreshToken).HasColumnName("Refresh Token");
            modelBuilder.Entity<User>().Property(b => b.RefreshTokenExpiryTime).HasColumnName("Refresh Token Expiry Time");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
