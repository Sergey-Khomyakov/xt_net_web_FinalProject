using System;
using System.Collections.Generic;
using DigitalLibrary.BLL.interfaces;
using DigitalLibrary.Entities;
using DigitalLibrary.DAL.interfaces;
using System.Linq;

namespace DigitalLibrary.BLL
{
    public class BookLogic : IBookLogic
    {
        private readonly IBookDAL _bookDAL;
        public BookLogic(IBookDAL bookDAL)
        {
            _bookDAL = bookDAL;
        }
        public void AddBook(Book book)
        {
            _bookDAL.AddBook(book);
        }

        public void DeleteById(int bookId)
        {
            _bookDAL.DeleteById(bookId);
        }

        public void EditBook(int bookId, Book editBook)
        {
            _bookDAL.EditBook(bookId, editBook);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookDAL.GetAll();
        }

        public Book GetById(int bookId)
        {
            return _bookDAL.GetAll().FirstOrDefault(item => item.Id == bookId);
        }
    }
}
