using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.DataAccessLayer.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}