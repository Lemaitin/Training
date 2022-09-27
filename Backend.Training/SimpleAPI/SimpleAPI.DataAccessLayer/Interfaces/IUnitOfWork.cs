using SimpleAPI.DataAccessLayer.Models;

namespace SimpleAPI.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<SecretModel> SecretModels { get; }
        IBaseRepository<CategoryModel> CategoryModels { get; }
        void Save();
    }
}