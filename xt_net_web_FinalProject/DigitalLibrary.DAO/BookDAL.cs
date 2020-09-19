using System;
using System.Collections.Generic;
using DigitalLibrary.DAL.interfaces;
using DigitalLibrary.Entities;
using System.Configuration;
using System.Data.SqlClient;
using Log4netHandler;

namespace DigitalLibrary.DAL
{
    public class BookDAL : IBookDAL
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        public int AddBook(Book book)
        {
            Logger.InitLogger();
            try
            {
                int returnValue = -1;
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "INSERT INTO [Book] (BookFile) VALUES (@param1) SELECT SCOPE_IDENTITY();";

                    command.Parameters.AddWithValue("@param1", book.BookFile);

                    connection.Open();                
                    command.ExecuteNonQuery();

                    object returnObj = command.ExecuteScalar();

                    if (returnObj != null)
                    {
                        int.TryParse(returnObj.ToString(), out returnValue);
                    }
                    Logger.Log.Info("Add new Book");
                    return returnValue;
                }
            }
            catch
            {
                Logger.Log.Error("Error in Add new Book");
                return 0;
            }

        }

        public void DeleteById(int bookId)
        {
            Logger.InitLogger();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "DELETE FROM [Book] WHERE [BookId] = @param1";
                    command.Parameters.AddWithValue("@param1", bookId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                Logger.Log.Info($"Delete {bookId} Book");
            }
            catch
            {
                Logger.Log.Error("Error in Delete Book");
            }

        }

        public void EditBook(int bookId, Book editBook)
        {
            Logger.InitLogger();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "UPDATE [User] SET [BookFile] = @param2 WHERE [BookId] = @param1";
                    command.Parameters.AddWithValue("@param1", bookId);
                    command.Parameters.AddWithValue("@param2", editBook.BookFile);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                Logger.Log.Info($"Editing Book {bookId}");
            }
            catch
            {
                Logger.Log.Error("Error in Editing Book");
            }

        }

        public IEnumerable<Book> GetAll()
        {
            Logger.InitLogger();
            try
            {            
                var books = new List<Book>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT * FROM [Book]";

                    connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        books.Add(new Book()
                        {
                            Id = (int)reader["BookId"],
                            BookFile = Convert.IsDBNull(reader["BookFile"]) ? new byte[] { } : (byte[])reader["BookFile"]
                        });
                    }
                }
                Logger.Log.Info("Show all Book");
                return books;
            }
            catch
            {
                Logger.Log.Error("Error in Show all Book");
                return null;
            }   
        }
    }
}
