using System;
using System.Collections.Generic;
using DigitalLibrary.Entities;

namespace DigitalLibrary.BLL.interfaces
{
    public interface IBookLogic
    {
        void AddBook(Book book);
        void DeleteById(int book);
        void EditBook(int bookId, Book editBook);
        Book GetById(int bookId);
        IEnumerable<Book> GetAll();
    }
}
