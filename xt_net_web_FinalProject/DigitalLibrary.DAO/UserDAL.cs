using System;
using System.Collections.Generic;
using DigitalLibrary.DAL.interfaces;
using DigitalLibrary.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace DigitalLibrary.DAL
{
    public class UserDAL : IUserDAL
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        public void AddUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO [User] (Login, Password, Role, Image) VALUES (@param1, @param2, @param3, @param4)";

                var loginParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Login",
                    Value = user.Login,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.AddWithValue("@param1", loginParameter);

                var passwordParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Password",
                    Value = user.Password,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.AddWithValue("@param2", passwordParameter);

                var RoleParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Role",
                    Value = user.Role,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.AddWithValue("@param3", RoleParameter);

                var imageParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Binary,
                    ParameterName = "@Image",
                    Value = user.Image,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.AddWithValue("@param4", imageParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteById(int userId)
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
        }

        public void EditUser(int userId, User editUser)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE [User] SET [Login] = @param2, [Password] = @param3, [Role] = @param4, [Image] = @param5 WHERE [Id] = @param1";
                command.Parameters.AddWithValue("@param1", userId);
                command.Parameters.AddWithValue("@param2", editUser.Login);
                command.Parameters.AddWithValue("@param3", editUser.Password);
                command.Parameters.AddWithValue("@param4", editUser.Role);
                command.Parameters.AddWithValue("@param5", editUser.Image);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAll()
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
                        Role = new string[] { reader["Role"] as string },
                        Image = Convert.IsDBNull(reader["Image"]) ? new byte[] { } : (byte[])reader["Image"]                      
                    });
                }
            }
            return users;
        }
    }
}
