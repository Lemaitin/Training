namespace SimpleAPI.DataAccessLayer.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task <IList<T>> GetAll();
        Task<T?> Get(int id);
        Task<T> Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}