using EF.CodeFirst.Training.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CodeFirst.Training.Services
{
    public class UserGenderService
    {
        public List<UserGenderModel> GetUserGenderAsync()
        {
            using UserContext context = new UserContext();

            List<UserGenderModel> usersGender = context.UsersGender.ToList();
            return usersGender;
        }

        public async Task<UserGenderModel> AddGenderAsync(UserGenderModel userGender)
        {
            using UserContext context = new UserContext();
            var entityEntry = await context.UsersGender.AddAsync(userGender);
            await context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public UserGenderModel UpdateGender(UserGenderModel userGender)
        {
            using UserContext context = new UserContext();
            var dbUser = context.UsersGender.FirstOrDefault(dbUser => dbUser.Id == userGender.Id);

            if (dbUser == null)
            {
                throw new ArgumentException();
            }

            try
            {
                dbUser.Gender = userGender.Gender;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return userGender;
        }

        public bool DeleteGender(int UserId)
        {
            using var context = new UserContext();
            var userGender = context.UsersGender.FirstOrDefault(userGender => userGender.Id == UserId);

            if (userGender == null)
            {
                return false;
            }

            try
            {
                context.UsersGender.Remove(userGender);
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