using System;
using System.Collections.Generic;
using System.Text;
using UserList.Core;

namespace UserList.Data
{
    public interface IUserData
    {
        IEnumerable<User> GetUserBySurname(string surname);
        User GetById(int id);
        User Update(User updatedUser);
        User Add(User newUser);
        User Delete(int id);
        int Commit();

    }
}
