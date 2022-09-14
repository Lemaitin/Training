using Microsoft.EntityFrameworkCore;
using SimpleAPI.DataAccessLayer.Models;

namespace SimpleAPI.DataAccessLayer

{
    public class SecretContext : DbContext
    {
        public SecretContext(DbContextOptions<SecretContext> options) : base(options)
        {

        }
        public DbSet<AccountModel> Account => Set<AccountModel>();
        public DbSet<CategoriesModel> Categories => Set<CategoriesModel>();
        public DbSet<SecretsModel> Secrets => Set<SecretsModel>();
    }
}