using Microsoft.EntityFrameworkCore;
using SimpleAPI.DataAccessLayer.Interfaces;
using SimpleAPI.DataAccessLayer.Models;

namespace SimpleAPI.DataAccessLayer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private SecretContext secretContext;
        private SecretRepository secretRepository;
        private CategoryRepository categoryRepository;

        public EFUnitOfWork(DbContextOptions<SecretContext> options)
        {
            secretContext = new SecretContext(options);
        }

        public IBaseRepository<SecretModel> SecretModels
        {
            get 
            {
                if (secretRepository == null)
                    secretRepository = new SecretRepository(secretContext);
                return secretRepository;
            }
        }

        public IBaseRepository<CategoryModel> CategoryModels
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(secretContext);
                return categoryRepository;
            }
        }

        public void Save()
        {
            secretContext.SaveChanges();
        }
    }
}