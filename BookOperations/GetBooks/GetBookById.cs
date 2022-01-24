using BookStore.Common;
using BookStore.DBOperations;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBookById
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBookById(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public GetBookByIdModel Handle(int id)
        {
            var book = _dbContext.Books.Where(x => x.Id == id).SingleOrDefault();

            if (book is null)
            {
                throw new InvalidOperationException("Kitap mevcut değil.");
            }
            else
            {
                GetBookByIdModel getBookByIdModel = new GetBookByIdModel();
                getBookByIdModel.Title = book.Title;
                getBookByIdModel.Genre = ((GenreEnum)book.GenreId).ToString();
                getBookByIdModel.PublisDate = book.PublisDate.Date.ToString("dd/MM/yyyy");
                getBookByIdModel.PageCount = book.PageCount;
                return getBookByIdModel;
            }
        }
    }
    public class GetBookByIdModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublisDate { get; set; }

    }
}
