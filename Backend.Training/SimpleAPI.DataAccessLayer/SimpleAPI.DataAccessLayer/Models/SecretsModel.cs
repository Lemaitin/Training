using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.DataAccessLayer.Models
{
    public class SecretsModel
    {
        [Key]
        public int SecretId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
