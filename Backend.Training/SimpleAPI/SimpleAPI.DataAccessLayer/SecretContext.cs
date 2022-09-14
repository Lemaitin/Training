using Microsoft.EntityFrameworkCore;
using SimpleAPI.DataAccessLayer.Models;

namespace SimpleAPI.DataAccessLayer

{
    public class SecretContext : DbContext
    {
        public SecretContext(DbContextOptions<SecretContext> options) : base(options)
        {

        }
        public DbSet<SecretModel> Account => Set<SecretModel>();
        public DbSet<CategoryModel> Categories => Set<CategoryModel>();
        public DbSet<AccountModel> Secrets => Set<AccountModel>();
    }
}