using System;
using System.Collections.Generic;
using DigitalLibrary.BLL.interfaces;
using DigitalLibrary.Entities;
using DigitalLibrary.DAL.interfaces;
using System.Linq;

namespace DigitalLibrary.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDAL _userDAL;
        public UserLogic(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public void AddUser(User user)
        {
            _userDAL.AddUser(user);
        }

        public void DeleteById(int userId)
        {
            _userDAL.DeleteById(userId);
        }

        public void EditUser(int userId, User editUser)
        {
            _userDAL.EditUser(userId, editUser);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDAL.GetAll();
        }

        public User GetById(int userId)
        {
            return _userDAL.GetAll().FirstOrDefault(item => item.Id == userId);
        }

        public User GetByLodin(string Login)
        {
            return _userDAL.GetAll().FirstOrDefault(item => item.Login == Login);
        }

        public string[] GetRolesForUser(string username)
        {
            var user = GetByLodin(username);

            return user == null ? new string[] { } : user.Role;
        }

        public bool IsUserInRole(string username, string role)
        {
            var user = GetByLodin(username);

            return user == null ? false : user.Role.Contains(role);
        }
    }
}
