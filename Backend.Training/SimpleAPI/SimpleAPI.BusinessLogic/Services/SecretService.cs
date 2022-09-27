using AutoMapper;
using SimpleAPI.BusinessLogicLayer.ViewModels;
using SimpleAPI.DataAccessLayer.Interfaces;
using SimpleAPI.DataAccessLayer.Models;

namespace SimpleAPI.BusinessLogicLayer.Services
{
    public class SecretService : ISecretService
    {
        IUnitOfWork _unitOfWork { get; set; }

        private readonly IMapper _mapper;

        public SecretService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task <IList<ViewSecretModel>> GetAllSecrets()
        {
            var secrets = await _unitOfWork.SecretModels.GetAll();
            var viewSecrets = _mapper.Map<IList<ViewSecretModel>>(secrets);
            return viewSecrets;
        }

        public async Task<ViewSecretModel> AddSecret(ViewSecretModel viewSecret)
        {
            try
            {
                var convertedSecret = _mapper.Map<SecretModel>(viewSecret);
                var addedSecret = await _unitOfWork.SecretModels.Add(convertedSecret);
                viewSecret.Id = addedSecret.Id;

                return viewSecret;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ViewSecretModel?> GetSecret(int id)
        {
            var secrets = await _unitOfWork.SecretModels.Get(id);
            var viewSecrets = _mapper.Map<ViewSecretModel>(secrets);
            return viewSecrets;
        }

        public bool UpdateSecret(ViewSecretModel viewSecret)
        {
            try
            {
                var convertedSecret = _mapper.Map<SecretModel>(viewSecret);
                _unitOfWork.SecretModels.Update(convertedSecret);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSecret(int id)
        {
            try
            {
                _unitOfWork.SecretModels.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}