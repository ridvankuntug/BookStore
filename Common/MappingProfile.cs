using AutoMapper;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.Application.BookOperations.GetBooks;
using BookStore.Application.GenreOperations.CreateGenre;
using BookStore.Application.GenreOperations.GetGenres;
using BookStore.Entities;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Books>();
            CreateMap<Books, GetBookByIdModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreName));
            CreateMap<Books, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreName));
            
            CreateMap<CreateGenreModel, Genres>();
            CreateMap<Genres, GetGenresModel>();
            CreateMap<Genres, GetGenresAllModel>();
            CreateMap<Genres, GetGenreByIdModel>();
        }
    }
}
