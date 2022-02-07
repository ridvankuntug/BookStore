using AutoMapper;
using BookStore.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.GenreOperations.GetGenres
{
    public class GetGenreByIdQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public int GenreId{ get; set; }
        public GetGenreByIdQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetGenreByIdModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(g => g.GenreId == GenreId);
            if (genre is not null)
            {
                GetGenreByIdModel genreObj = _mapper.Map<GetGenreByIdModel>(genre);
                return genreObj;
            }
            else
            {
                throw new InvalidOperationException("Kitap türü bulunamadı!");
            }
        }
    }

    public class GetGenreByIdModel
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public bool IsActive { get; set; }
    }
}
