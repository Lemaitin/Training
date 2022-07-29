using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF.CodeFirst.Training.DataModel
{
    public class UserContext : DbContext
    {
        public UserContext()
        {
        }

        public DbSet<UserGenderModel> UsersGender { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile($"appsettings.json");

            var config = configuration.Build();
            var connectionString = config.GetConnectionString("SqlConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGenderModel>()
                .HasOne(x => x.User)
                .WithOne(x => x.Gender)
                .HasForeignKey<UserModel>(x => x.GenderId);
        }
    }
}