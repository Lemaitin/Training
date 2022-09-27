using Microsoft.EntityFrameworkCore;
using SimpleAPI.DataAccessLayer.Interfaces;
using SimpleAPI.DataAccessLayer.Models;

namespace SimpleAPI.DataAccessLayer.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private SecretContext _secretContext;
        public BaseRepository(SecretContext secretContext)
        {
            _secretContext = secretContext;
        }

        public async Task <IList<T>> GetAll()
        {
            return await _secretContext.Set<T>().ToListAsync();
        }

        public async Task<T?> Get(int id)
        {
            return await _secretContext.Set<T>().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<T> Add(T item)
        {
            var sec = await _secretContext.Set<T>().AddAsync(item);
            _secretContext.SaveChanges();
            return sec.Entity;
        }

        public void Update(T item)
        {
            _secretContext.Set<T>().Update(item);
            _secretContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _secretContext.Set<T>().FirstOrDefault(s => s.Id == id);
            if (entity == null)
            {
                return;
            }
            _secretContext.Set<T>().Remove(entity);
            _secretContext.SaveChanges();
        }
    }
}