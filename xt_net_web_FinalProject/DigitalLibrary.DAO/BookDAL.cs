using System;
using System.Collections.Generic;
using DigitalLibrary.DAL.interfaces;
using DigitalLibrary.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace DigitalLibrary.DAL
{
    public class BookDAL : IBookDAL
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        public int AddBook(Book book)
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
                return returnValue;
            }
        }

        public void DeleteById(int bookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM [Book] WHERE [Id] = @param1";
                command.Parameters.AddWithValue("@param1", bookId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditBook(int bookId, Book editBook)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE [User] SET [BookFile] = @param2 WHERE [Id] = @param1";
                command.Parameters.AddWithValue("@param1", bookId);
                command.Parameters.AddWithValue("@param2", editBook.BookFile);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Book> GetAll()
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
                        Id = (int)reader["Id"],
                        BookFile = Convert.IsDBNull(reader["BookFile"]) ? new byte[] { } : (byte[])reader["BookFile"]
                    });
                }
            }
            return books;
        }
    }
}
