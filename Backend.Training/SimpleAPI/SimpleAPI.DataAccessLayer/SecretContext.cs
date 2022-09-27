using Microsoft.EntityFrameworkCore;
using SimpleAPI.DataAccessLayer.Models;
using System.Reflection;

namespace SimpleAPI.DataAccessLayer

{
    public class SecretContext : DbContext
    {
        public SecretContext(DbContextOptions<SecretContext> options) : base(options)
        {

        }

        public DbSet<SecretModel> Secrets => Set<SecretModel>();
        public DbSet<CategoryModel> Categories => Set<CategoryModel>();
        public DbSet<AccountModel> Account => Set<AccountModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}