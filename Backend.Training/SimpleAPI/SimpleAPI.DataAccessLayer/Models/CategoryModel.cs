using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.DataAccessLayer.Models
{
    public class CategoryModel : BaseModel
    {
        public string CategoryName { get; set; } = string.Empty;
    }
}