using AutoMapper;
using BookStore.DBOperations;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.GenreOperations.GetGenres
{
    public class GetGenresAllQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenresAllQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetGenresAllModel> Handle()
        {
            var genres = _context.Genres.OrderBy(g => g.GenreId);
            List<GetGenresAllModel> genresObj = _mapper.Map<List<GetGenresAllModel>>(genres);
            return genresObj;
        }
    }

    public class GetGenresAllModel
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public bool IsActive { get; set; }
    }
}
