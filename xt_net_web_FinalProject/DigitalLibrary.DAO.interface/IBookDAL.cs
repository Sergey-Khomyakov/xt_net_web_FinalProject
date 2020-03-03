using System;
using System.Collections.Generic;
using DigitalLibrary.Entities;

namespace DigitalLibrary.DAL.interfaces
{
    public interface IBookDAL
    {
        void AddBook(Book book);
        void DeleteById(int bookId);
        void EditBook(int bookId, Book editBook);
        IEnumerable<Book> GetAll();
    }
}
