using EF.DatabaseFirst.Training;

UserService service = new UserService();

UserModel useradd = new UserModel { UserId = 1, FirstName = "Oleg", LastName = "Lisuk", Email = "OlegLisuk@gmail.com", PhoneNumber = "+375294627382", Gender = "Male" };
service.Delete(useradd.UserId);
var a = service.AddAsync(useradd).GetAwaiter().GetResult();
if (a != null)
{
    Console.WriteLine($"User with {a.FirstName} {a.LastName} {a.Email} {a.PhoneNumber} {a.Gender} was added.");
}
useradd.FirstName = "Dmitriy";
var b = service.Update(useradd);
if (b != null)
{
    Console.WriteLine($"User with UserID {b.UserId}: {b.FirstName} {b.LastName} {b.Email} {b.PhoneNumber} {b.Gender} was updated");
}
service.GetUsersAsync();
var c = service.Delete(useradd.UserId);
if (c)
{
    Console.WriteLine("User was deleted");
}

service.GetUsersAsync();

Console.ReadKey();