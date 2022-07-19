using System.ComponentModel.DataAnnotations;

namespace EF.CodeFirst.Training.DataModel
{
    public class User
    {
        public int UserId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [MaxLength(30)]
        public string Gender { get; set; }

        [MaxLength(30)]
        public string Salary { get; set; }
    }
}
