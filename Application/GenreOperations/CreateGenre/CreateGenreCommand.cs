using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entities;
using System;
using System.Linq;

namespace BookStore.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
        var genre = _context.Genres.SingleOrDefault(genre => genre.GenreName == Model.GenreName);
            Genres genreObj = _mapper.Map<Genres>(Model);
            if(genre is not null)
            {
                throw new InvalidOperationException("Kitap türü zaten mevcut.");
            }
            else
            {
                _context.Genres.Add(genreObj);
                _context.SaveChanges();
            }
        }


    }

    public class CreateGenreModel
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }

}
