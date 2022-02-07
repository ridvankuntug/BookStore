using AutoMapper;
using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(g => g.GenreId == GenreId);
            if (genre is not null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Kitap türü bulunamadı.");
            }
        }
    }
}
