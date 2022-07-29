using EF.CodeFirst.Training.DataModel;
using EF.CodeFirst.Training.Services;

UserService service = new UserService();
UserGenderService genderService = new UserGenderService();

service.GetUsersAsync();

UserModel useradd = new UserModel { FirstName = "Oleg", LastName = "Lisuk", Email = "OlegLisuk@gmail.com", PhoneNumber = "+375294627382", GenderId = 1, Salary = "2000$" };

UserGenderModel userGenderAdd = new UserGenderModel { Gender = "asdasdasdasdasd" };

service.Delete(useradd.Id);

var addGender = genderService.AddGenderAsync(userGenderAdd).GetAwaiter().GetResult();
if (addGender != null)
{
    Console.WriteLine($"User Gender {addGender.Gender} was added");
}

userGenderAdd.Gender = "Male";
var upUserGender = genderService.UpdateGender(userGenderAdd);
if (upUserGender != null)
{
    Console.WriteLine($"User with UserID {upUserGender.Id}: {upUserGender.Gender} was updated");
}

var addUser = service.AddAsync(useradd).GetAwaiter().GetResult();
if (addUser != null)
{
    Console.WriteLine($"User with {addUser.FirstName} {addUser.LastName} {addUser.Email} {addUser.PhoneNumber} {addUser.GenderId} {addUser.Salary} was added.");
}

useradd.FirstName = "Dmitriy";
var upUser = service.Update(useradd);
if (upUser != null)
{
    Console.WriteLine($"User with UserID {upUser.Id}: {upUser.FirstName} {upUser.LastName} {upUser.Email} {upUser.PhoneNumber} {upUser.GenderId} {upUser.Salary} was updated");
}

var getUser = service.GetUsersAsync();
Console.WriteLine("Список пользователей:");
foreach (UserModel user in getUser)
{
    Console.WriteLine($" {user.Id}. {user.FirstName} {user.LastName} , {user.Email} , {user.PhoneNumber} , {user.GenderId} , {user.Salary}");
}

var getUserGender = genderService.GetUserGenderAsync();
Console.WriteLine("Пол сотрудников:");
foreach (UserGenderModel userGender in getUserGender)
{
    Console.WriteLine($" {userGender.Id}. {userGender.Gender}");
}

var delUser = service.Delete(useradd.Id);
if (delUser)
{
    Console.WriteLine("User was deleted");
}

var delUserGender = genderService.DeleteGender(userGenderAdd.Id);
if (delUserGender)
{
    Console.WriteLine("UserGender was deleted");
}

service.GetUsersAsync();