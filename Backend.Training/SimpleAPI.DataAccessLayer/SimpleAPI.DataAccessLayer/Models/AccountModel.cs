
using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.DataAccessLayer.Models

{
    public class AccountModel
    {
        [Key]
        public int AccountId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string SecretName { get; set; } = string.Empty;
        public string SecretValue { get; set; } = string.Empty;
        public string URL { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public int Category { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastModificationTime { get; set; }

        public virtual ICollection<CategoriesModel> CategoryName { get; set; }
    }
}