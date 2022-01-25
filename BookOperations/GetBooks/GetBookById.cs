using AutoMapper;
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
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookById(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public GetBookByIdModel Handle()
        {
            var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();

            if (book is null)
            {
                throw new InvalidOperationException("Kitap mevcut değil.");
            }
            else
            {
                GetBookByIdModel getBookByIdModel = _mapper.Map<GetBookByIdModel>(book);
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
