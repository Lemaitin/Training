using EF.CodeFirst.Training.DataModel;

namespace EF.CodeFirst.Training.Services
{
    public class UserService
    {
        public List<UserModel> GetUsersAsync()
        {
            using UserContext context = new UserContext();

            List<UserModel> users = context.Users.ToList();
            return users.ToList();
        }

        public async Task<UserModel> AddAsync(UserModel user)
        {
            using UserContext context = new UserContext();

            var entityEntry = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public UserModel Update(UserModel user)
        {
            using UserContext context = new UserContext();
            var dbUser = context.Users.FirstOrDefault(x => x.Id == user.Id);

            if (dbUser == null)
            {
                throw new ArgumentException();
            }

            try
            {
                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.Email = user.Email;
                dbUser.PhoneNumber = user.PhoneNumber;
                dbUser.Gender = user.Gender;
                context.Update(dbUser);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        public bool Delete(int userId)
        {
            using var context = new UserContext();
            var user = context.Users.FirstOrDefault(user => user.Id == userId);

            if (user == null)
            {
                return false;
            }

            try
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}