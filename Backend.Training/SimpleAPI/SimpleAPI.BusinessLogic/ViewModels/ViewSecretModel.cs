namespace SimpleAPI.BusinessLogicLayer.ViewModels
{
    public class ViewSecretModel : BaseViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string SecretName { get; set; } = string.Empty;
        public string SecretValue { get; set; } = string.Empty;
        public string URL { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string ExpirationDate { get; set; } = string.Empty;
        public string CreationTime { get; set; } = string.Empty;
        public string LastModificationTime { get; set; } = string.Empty;
    }
}