using System;
using DigitalLibrary.BLL.interfaces;
using DigitalLibrary.BLL;
using DigitalLibrary.DAL.interfaces;
using DigitalLibrary.DAL;

namespace DigitalLibrary.Common
{
    public static class DependencyResolver
    {
        public static IUserLogic UserLogic { get; }
        public static IUserDAL UserDAL { get; }
        public static IBookLogic BookLogic { get; }
        public static IBookDAL BookDAL { get; }
        public static IBookModelLogic BookModelLogic { get; }
        public static IBookModelDAL BookModelDAL { get; }
        static DependencyResolver()
        {
            UserDAL = new UserDAL();
            UserLogic = new UserLogic(UserDAL);
            BookDAL = new BookDAL();
            BookLogic = new BookLogic(BookDAL);
            BookModelDAL = new BookModelDAL();
            BookModelLogic = new BookModelLogic(BookModelDAL);
        }
    }
}
