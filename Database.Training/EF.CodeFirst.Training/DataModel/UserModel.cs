using System.ComponentModel.DataAnnotations;

namespace EF.CodeFirst.Training.DataModel
{
    public class UserModel : BaseModel
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [MaxLength(30)]
        public string Salary { get; set; }

        public UserGenderModel Gender { get; set; }
        public int GenderId { get; set; }
    }
}