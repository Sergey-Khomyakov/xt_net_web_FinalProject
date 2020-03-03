using System;
using System.Collections.Generic;
using DigitalLibrary.BLL.interfaces;
using DigitalLibrary.Entities;
using DigitalLibrary.DAL.interfaces;
using System.Linq;

namespace DigitalLibrary.BLL
{
    public class BookModelLogic : IBookModelLogic
    {
        private readonly IBookModelDAL _bookModelDAL;
        public BookModelLogic(IBookModelDAL bookModelDAL)
        {
            _bookModelDAL = bookModelDAL;
        }
        public void AddBookModel(BookModel bookModel)
        {
            _bookModelDAL.AddBookModel(bookModel);
        }

        public void DeleteById(int bookModelId)
        {
            _bookModelDAL.DeleteById(bookModelId);
        }

        public void EditBookModel(int bookModelId, BookModel editBookModel)
        {
            _bookModelDAL.EditBookModel(bookModelId, editBookModel);
        }

        public IEnumerable<BookModel> GetAll()
        {
            return _bookModelDAL.GetAll();
        }

        public BookModel GetById(int bookModelId)
        {
            return _bookModelDAL.GetAll().FirstOrDefault(item => item.Id == bookModelId);
        }
    }
}
