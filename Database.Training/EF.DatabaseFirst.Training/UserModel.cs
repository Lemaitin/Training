using System.ComponentModel.DataAnnotations;

namespace EF.DatabaseFirst.Training
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Gender { get; set; }
    }
}