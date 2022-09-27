using SimpleAPI.BusinessLogicLayer.ViewModels;

namespace SimpleAPI.BusinessLogicLayer.Services
{
    public interface ISecretService
    {
        Task<IList<ViewSecretModel>> GetAllSecrets();

        Task<ViewSecretModel> AddSecret(ViewSecretModel viewSecret);

        Task<ViewSecretModel?> GetSecret(int id);

        bool UpdateSecret(ViewSecretModel viewSecret);

        bool DeleteSecret(int id);
    }
}