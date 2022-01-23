﻿using BookStore.DBOperations;
using BookStore.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);

            if (book is null)
            {
                throw new InvalidOperationException("Kitap mevcut değil.");
            }
            else
            {
                book.Title = Model.Title != default ? Model.Title : book.Title;
                book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
                book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
                book.PublisDate = Model.PublisDate != default ? Model.PublisDate : book.PublisDate;
                _dbContext.SaveChanges();
            }
        }

    }
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublisDate { get; set; }
    }
}
