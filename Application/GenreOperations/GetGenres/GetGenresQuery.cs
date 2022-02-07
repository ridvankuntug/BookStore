using AutoMapper;
using BookStore.DBOperations;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.GenreOperations.GetGenres
{
    public class GetGenresQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetGenresModel> Handle()
        {
            var genres = _context.Genres.Where(g => g.IsActive).OrderBy(g => g.GenreId);
            List<GetGenresModel> genresObj = _mapper.Map<List<GetGenresModel>>(genres);
            return genresObj;
        }
    }

    public class GetGenresModel
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
