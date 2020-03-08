using System;
using System.Collections.Generic;
using DigitalLibrary.DAL.interfaces;
using DigitalLibrary.Entities;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Log4netHandler;
namespace DigitalLibrary.DAL
{
    public class UserDAL : IUserDAL
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        public void AddUser(User user)
        {
            Logger.InitLogger();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "INSERT INTO [User] (Login, Password, Role, Image, Name, FamilyName) VALUES (@param1, @param2, @param3, @param4, @param5, @param6)";

                    command.Parameters.AddWithValue("@param1", user.Login);
                    command.Parameters.AddWithValue("@param2", user.Password);
                    command.Parameters.AddWithValue("@param3", user.Role[0]);
                    command.Parameters.AddWithValue("@param4", user.Image);
                    command.Parameters.AddWithValue("@param5", user.Name);
                    command.Parameters.AddWithValue("@param6", user.FamilyName);

                    connection.Open();
                    command.ExecuteNonQuery();
                
                    Logger.Log.Info("Add new User");
                }
            }
            catch 
            {
                Logger.Log.Error("Error in Add new User");
            }
           
        }

        public void DeleteById(int userId)
        {
            Logger.InitLogger();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "DELETE FROM [User] WHERE [Id] = @param1";
                    command.Parameters.AddWithValue("@param1", userId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                Logger.Log.Info($"User {userId} Delete");
            }
            catch
            {
                Logger.Log.Error("Error in Delete User");
            }

        }

        public void EditUser(int userId, User editUser)
        {
            Logger.InitLogger();
            try
            {
               var user = GetAll().FirstOrDefault(item => item.Id == userId);

                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "UPDATE [User] SET [Login] = @param2, [Password] = @param3, [Role] = @param4, [Image] = @param5, [Name] = @param6, [FamilyName] = @param7 WHERE [Id] = @param1";
                    command.Parameters.AddWithValue("@param1", userId);

                    _ = editUser.Login == "" ? command.Parameters.AddWithValue("@param2", user.Login) : command.Parameters.AddWithValue("@param2", editUser.Login);
                    _ = editUser.Password == "" ? command.Parameters.AddWithValue("@param3", user.Password) : command.Parameters.AddWithValue("@param3", editUser.Password);
                    command.Parameters.AddWithValue("@param4", user.Role[0]);
                    _ = editUser.Image.Length == 0 ? command.Parameters.AddWithValue("@param5", user.Image) : command.Parameters.AddWithValue("@param5", editUser.Image);
                    _ = editUser.Name == "" ? command.Parameters.AddWithValue("@param6", user.Name) : command.Parameters.AddWithValue("@param6", editUser.Name);
                    _ = editUser.FamilyName == "" ? command.Parameters.AddWithValue("@param7", user.FamilyName) : command.Parameters.AddWithValue("@param7", editUser.FamilyName);

                    connection.Open();
                    command.ExecuteNonQuery();
                    Logger.Log.Info($"User {user.Id} Editing");
                }
            }
            catch
            {
                Logger.Log.Error("Error in Editing user");
            }
 
        }

        public IEnumerable<User> GetAll()
        {

            Logger.InitLogger();
            try
            {
              var users = new List<User>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT * FROM [User]";

                    connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        users.Add(new User()
                        {
                            Id = (int)reader["Id"],
                            Login = reader["Login"] as string,
                            Password = reader["Password"] as string,
                            Name = reader["Name"] as string,
                            FamilyName = reader["FamilyName"] as string,
                            Role = new string[] { reader["Role"] as string },
                            Image = Convert.IsDBNull(reader["Image"]) ? new byte[] { } : (byte[])reader["Image"]                      
                        });
                    }
                }
                Logger.Log.Info("Show All Users");
                return users;              
            }
            catch
            {
                Logger.Log.Error("Error in Get All User");
                return null;
            }
        }
    }
}
