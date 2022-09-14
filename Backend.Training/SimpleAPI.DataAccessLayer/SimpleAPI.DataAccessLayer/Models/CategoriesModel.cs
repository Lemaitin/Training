using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.DataAccessLayer.Models
{
    public class CategoriesModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public AccountModel Category { get; set; }
    }
}