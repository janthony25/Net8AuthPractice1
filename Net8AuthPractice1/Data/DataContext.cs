using Microsoft.EntityFrameworkCore;
using Net8AuthPractice1.Models;

namespace Net8AuthPractice1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.PasswordHash).IsRequired().HasMaxLength(60);
            modelBuilder.Entity<User>().Property(u => u.Role).IsRequired();

            // Ignore the Password property
            modelBuilder.Entity<User>().Ignore(u => u.Password);

            // Seed the admin user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Calupcupan@ntonio!09"),
                    Role = "Admin"
                }
            );
        }
    }
}
