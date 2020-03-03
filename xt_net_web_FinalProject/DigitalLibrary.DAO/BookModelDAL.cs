using System;
using System.Collections.Generic;
using DigitalLibrary.DAL.interfaces;
using DigitalLibrary.Entities;
using System.Configuration;
using System.Data.SqlClient;

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

                var authorParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Author",
                    Value = bookModel.Author,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.AddWithValue("@param1", authorParameter);

                var titleParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Title",
                    Value = bookModel.Title,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.AddWithValue("@param2", titleParameter);


                var genreParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Genre",
                    Value = bookModel.Genre,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.AddWithValue("@param3", genreParameter);

                var descriptionParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Description",
                    Value = bookModel.Description,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.AddWithValue("@param4", descriptionParameter);

                var dateCreatedBookParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.DateTime,
                    ParameterName = "@DateCreatedBook",
                    Value = bookModel.DateCreatedBook,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.AddWithValue("@param5", dateCreatedBookParameter);

                var imageParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Binary,
                    ParameterName = "@Image",
                    Value = bookModel.Image,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.AddWithValue("@param6", imageParameter);

                var pagesParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Pages",
                    Value = bookModel.Pages,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.AddWithValue("@param7", pagesParameter);

                var idBookParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@IdBook",
                    Value = bookModel.IdBook,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.AddWithValue("@param8", idBookParameter);

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
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE [BookModel] SET [Author] = @param2, [Title] = @param3, [Genre] = @param4, [Description] = @param5, [DateCreatedBook] = @param6, [Image] = @param7, [Pages] = @param8, [IdBook] = @param9 WHERE [Id] = @param1";
                command.Parameters.AddWithValue("@param1", bookModelId);
                command.Parameters.AddWithValue("@param2", editBookModel.Author);
                command.Parameters.AddWithValue("@param3", editBookModel.Title);
                command.Parameters.AddWithValue("@param4", editBookModel.Genre);
                command.Parameters.AddWithValue("@param5", editBookModel.Description);
                command.Parameters.AddWithValue("@param6", editBookModel.DateCreatedBook);
                command.Parameters.AddWithValue("@param7", editBookModel.Image);
                command.Parameters.AddWithValue("@param8", editBookModel.Pages);
                command.Parameters.AddWithValue("@param9", editBookModel.IdBook);

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
