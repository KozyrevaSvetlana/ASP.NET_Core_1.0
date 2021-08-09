using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IUsersRepository
    {
        IEnumerable<UserViewModel> AllUsers { get; }

        void AddUser(UserViewModel user);
        void DeleteUser(UserViewModel user);
        void EditUser(UserViewModel editUser);
        UserViewModel GetUserByEmail(string email);
        UserViewModel GetUserByPhone(string phone);
        bool IsUnique(string name);
        UserViewModel GetUserByName(string name);
        bool Contains(string name);
        UserViewModel GetUserById(string id);
    }
}