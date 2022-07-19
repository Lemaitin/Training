using EF.CodeFirst.Training.DataModel;

using UserContext context = new UserContext();
{
    User user = new User();
    user.FirstName = "Dmitriy";
    user.LastName = "Snitko";
    user.Email = "DmitriySnitko@gmail.com";
    user.PhoneNumber = "+375447428182";
    user.Gender = "Male";
    user.Salary = "2000";

    context.Users.Add(user);
    context.SaveChanges();
}
