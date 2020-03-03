using System;
using System.Collections.Generic;
using DigitalLibrary.Entities;

namespace DigitalLibrary.DAL.interfaces
{
    public interface IUserDAL
    {
        void AddUser(User user);
        void DeleteById(int userId);
        void EditUser(int userId, User editUser);
        IEnumerable<User> GetAll();
    }
}
