using System;
using System.Collections.Generic;
using DigitalLibrary.Entities;

namespace DigitalLibrary.BLL.interfaces
{
    public interface IBookModelLogic
    {
        void AddBookModel(BookModel bookModel);
        void DeleteById(int bookModelId);
        void EditBookModel(int bookModelId, BookModel editBookModel);
        BookModel GetById(int bookModelId);
        IEnumerable<BookModel> GetAll();
    }
}
