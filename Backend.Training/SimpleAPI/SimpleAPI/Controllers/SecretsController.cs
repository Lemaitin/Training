using Microsoft.AspNetCore.Mvc;
using SimpleAPI.BusinessLogicLayer.Services;
using SimpleAPI.BusinessLogicLayer.ViewModels;

namespace SimpleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretsController : ControllerBase
    {
        private readonly ISecretService _secretService;

        public SecretsController(ISecretService secretService)
        {
            _secretService = secretService;
        }

        //Get All Secrets
        [HttpGet("GetAllSecrets")]
        public async Task <IList<ViewSecretModel>> GetAll()
        {
            return await _secretService.GetAllSecrets();
        }

        //Add Secret
        [HttpPost("AddSecret")]
        public async Task<ViewSecretModel> AddSecret(ViewSecretModel viewSecret)
        {
            return await _secretService.AddSecret(viewSecret);
        }


        //Get Secret
        [HttpGet("GetSecret")]
        public async Task<ViewSecretModel?> GetSecret(int id)
        {
            return await _secretService.GetSecret(id);
        }

        //Update Secrets
        [HttpPut("UpdateSecret")]
        public bool UpdateSecret(ViewSecretModel viewSecret)
        {
            return _secretService.UpdateSecret(viewSecret);
        }

        //Delete Secret
        [HttpDelete("DeleteSecret")]
        public bool DeleteSecret(int id)
        {
            return _secretService.DeleteSecret(id);
        }
    }
}