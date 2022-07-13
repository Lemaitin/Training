namespace EF.DatabaseFirst.Training
{
    public class UserService
    {
        public List<UserModel> GetUsersAsync()
        {
            using CommonContext context = new CommonContext();

            List<UserModel> users = context.Users.ToList();
            Console.WriteLine("Список пользователей:");
            for (int i = 0; i < users.Count; i++)
            {
                UserModel u = users[i];
                Console.WriteLine($"{u.UserId}.{u.FirstName} {u.LastName} , {u.Email} , {u.PhoneNumber} , {u.Gender}");
            }
            return users.ToList();

        }

        public async Task<UserModel> AddAsync(UserModel user)
        {
            using CommonContext context = new CommonContext();

            var entityEntry = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public UserModel Update(UserModel user)
        {
            using CommonContext context = new CommonContext();
            var dbUser = context.Users.FirstOrDefault(x => x.UserId == user.UserId);

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
            using var context = new CommonContext();
            var user = context.Users.FirstOrDefault(user => user.UserId == userId);

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