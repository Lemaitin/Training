using SimpleAPI.DataAccessLayer.Interfaces;
using SimpleAPI.DataAccessLayer.Models;

namespace SimpleAPI.DataAccessLayer.Repositories
{
    public class SecretRepository : BaseRepository<SecretModel>, ISecretRepository
    {
        public SecretRepository(SecretContext secretContext) : base(secretContext)
        {

        }
    }
}