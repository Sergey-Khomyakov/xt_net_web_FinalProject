using System;
using DigitalLibrary.Entities;
using System.Collections.Generic;

namespace DigitalLibrary.BLL.interfaces
{
    public interface IUserLogic
    {
        void AddUser(User user);
        void DeleteById(int userId);
        void EditUser(int userId, User editUser);
        User GetById(int userId);
        bool IsUserInRole(string username, string roleName);
        IEnumerable<User> GetAll();
        string[] GetRolesForUser(string username);
        bool CheckUser(string login, string password);
        User GetByLodin(string Login);
    }
}
