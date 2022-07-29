using System.ComponentModel.DataAnnotations;

namespace EF.CodeFirst.Training.DataModel
{
    public class UserGenderModel : BaseModel
    {
        [MaxLength(30)]
        public string Gender { get; set; }
        public UserModel User { get; set; }
    }
}