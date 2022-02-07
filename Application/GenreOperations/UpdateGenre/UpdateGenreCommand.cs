using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(g => g.GenreId == GenreId);
            if (genre is not null)
            {
                if (_context.Genres.Any(g => g.GenreName.ToLower() == Model.GenreName.ToLower() && g.GenreId != GenreId))
                {
                    throw new InvalidOperationException("Aynı isimli bir kitap zaten mevcut.");
                }
                else
                {
                    genre.GenreName = string.IsNullOrEmpty(Model.GenreName.Trim()) ? genre.GenreName : Model.GenreName;
                    genre.IsActive = Model.IsActive;
                    _context.SaveChanges();
                }
            }
            else
            {
                throw new InvalidOperationException("Kitap türü bulunamadı.");
            }
        }
    }

    public class UpdateGenreModel
    {
        public string GenreName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
