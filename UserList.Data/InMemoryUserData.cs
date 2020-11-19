using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserList.Core;

namespace UserList.Data
{
    public class InMemoryUserData : IUserData
    {
        readonly List<User> users;
        public InMemoryUserData()
        {
            users = new List<User>()
            {
                new User {Id = 1, Name = "Mateusz", Surname = "Walczyk", Country = "Polska", Email = "mateusz@gmail.com", Gender = Gender.Male, DateOfBirthday = new DateTime(1995, 8, 10)},
                new User {Id = 2, Name = "Maria", Surname = "Kowalska", Country = "Polska", Email = "maria@gmail.com", Gender = Gender.Female, DateOfBirthday = new DateTime(1995, 8, 10)},
                new User {Id = 3, Name = "Mariusz", Surname = "Nowak", Country = "Polska", Email = "mariusz@gmail.com", Gender = Gender.Male, DateOfBirthday = new DateTime(1995, 8, 10)},
            };
        }
        public User GetById(int id)
        {
            return users.SingleOrDefault(u => u.Id == id);
        }
        public User Add(User newUser)
        {
            users.Add(newUser);
            newUser.Id = users.Max(u => u.Id) + 1;
            return newUser;
        }
        public User Update(User updatedUser)
        {
            var user = users.SingleOrDefault(u => u.Id == updatedUser.Id);
            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.Surname = updatedUser.Surname;
                user.Country = updatedUser.Country;
                user.Email = updatedUser.Email;
                user.DateOfBirthday = updatedUser.DateOfBirthday;
                user.Gender = updatedUser.Gender;
            }
            return user;
        }
        public int Commit()
        {
            return 0;
        }
        public IEnumerable<User> GetUserBySurname(string surname)
        {
            return from u in users
                   where string.IsNullOrEmpty(surname) || u.Surname.StartsWith(surname)
                   orderby u.Surname
                   select u;
        }


        public User Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
            }
            return null;
        }



    }
}
