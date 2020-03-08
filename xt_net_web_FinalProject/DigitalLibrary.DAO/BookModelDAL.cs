using System;
using System.Collections.Generic;
using DigitalLibrary.DAL.interfaces;
using DigitalLibrary.Entities;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace DigitalLibrary.DAL
{
    public class BookModelDAL : IBookModelDAL
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;

        public void AddBookModel(BookModel bookModel)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO [BookModel] (Author, Title, Genre, Description, DateCreatedBook, Image, Pages, IdBook) VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8)";

                command.Parameters.AddWithValue("@param1", bookModel.Author);
                command.Parameters.AddWithValue("@param2", bookModel.Title);
                command.Parameters.AddWithValue("@param3", bookModel.Genre);
                command.Parameters.AddWithValue("@param4", bookModel.Description);
                command.Parameters.AddWithValue("@param5", bookModel.DateCreatedBook);
                command.Parameters.AddWithValue("@param6", bookModel.Image);
                command.Parameters.AddWithValue("@param7", bookModel.Pages);
                command.Parameters.AddWithValue("@param8", bookModel.IdBook);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteById(int bookModelId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM [BookModel] WHERE [Id] = @param1";
                command.Parameters.AddWithValue("@param1", bookModelId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditBookModel(int bookModelId, BookModel editBookModel)
        {
            var book = GetAll().FirstOrDefault(item => item.Id == bookModelId);

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE [BookModel] SET [Author] = @param2, [Title] = @param3, [Genre] = @param4, [Description] = @param5, [DateCreatedBook] = @param6, [Image] = @param7, [Pages] = @param8, [IdBook] = @param9 WHERE [Id] = @param1";
                command.Parameters.AddWithValue("@param1", bookModelId);
                _ = editBookModel.Author == "" ? command.Parameters.AddWithValue("@param2", book.Author) : command.Parameters.AddWithValue("@param2", editBookModel.Author);
                _ = editBookModel.Title == "" ? command.Parameters.AddWithValue("@param3", book.Title) : command.Parameters.AddWithValue("@param3", editBookModel.Title);
                _ = editBookModel.Genre == "" ? command.Parameters.AddWithValue("@param4", book.Genre) : command.Parameters.AddWithValue("@param4", editBookModel.Genre);
                _ = editBookModel.Description == "" ? command.Parameters.AddWithValue("@param5", book.Description) : command.Parameters.AddWithValue("@param5", editBookModel.Description);
                _ = editBookModel.DateCreatedBook.Year < 1754 ? command.Parameters.AddWithValue("@param6", book.DateCreatedBook) : command.Parameters.AddWithValue("@param6", editBookModel.DateCreatedBook);
                _ = editBookModel.Image.Length == 0 ? command.Parameters.AddWithValue("@param7", book.Image) : command.Parameters.AddWithValue("@param7", editBookModel.Image);
                _ = editBookModel.Pages == 0 ? command.Parameters.AddWithValue("@param8", book.Pages) : command.Parameters.AddWithValue("@param8", editBookModel.Pages);
                _ = editBookModel.IdBook == 0 ? command.Parameters.AddWithValue("@param9", book.IdBook) : command.Parameters.AddWithValue("@param9", editBookModel.IdBook);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<BookModel> GetAll()
        {
            var bookModels = new List<BookModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM [BookModel]";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bookModels.Add(new BookModel()
                    {
                        Id = (int)reader["Id"],
                        Author = reader["Author"] as string,
                        Title = reader["Title"] as string,
                        Pages = (int) reader["Pages"],
                        Image = Convert.IsDBNull(reader["Image"]) ? new byte[] { } : (byte[])reader["Image"],
                        DateCreatedBook = (DateTime)reader["DateCreatedBook"],
                        Genre = reader["Genre"] as string,
                        Description = reader["Description"] as string,
                        IdBook = (int) reader["IdBook"]
                    });
                }
            }
            return bookModels;
        }
    }
}
