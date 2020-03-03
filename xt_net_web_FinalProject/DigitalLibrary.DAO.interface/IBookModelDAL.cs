using System;
using System.Collections.Generic;
using DigitalLibrary.Entities;

namespace DigitalLibrary.DAL.interfaces
{
    public interface IBookModelDAL
    {
        void AddBookModel(BookModel bookModel);
        void DeleteById(int bookModelId);
        void EditBookModel(int bookModelId, BookModel editBookModel);
        IEnumerable<BookModel> GetAll();
    }
}
