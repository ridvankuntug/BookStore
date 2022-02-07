using AutoMapper;
using BookStore.Application.GenreOperations.CreateGenre;
using BookStore.Application.GenreOperations.DeleteGenre;
using BookStore.Application.GenreOperations.GetGenres;
using BookStore.Application.GenreOperations.UpdateGenre;
using BookStore.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres(bool checkAll)
        {

            if (checkAll)
            {
                GetGenresAllQuery query = new GetGenresAllQuery(_context, _mapper);
                var genreObj = query.Handle();

                return Ok(genreObj);

            }
            else
            {
                GetGenresQuery query = new GetGenresQuery(_context, _mapper);
                var genreObj = query.Handle();

                return Ok(genreObj);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id)
        {
            GetGenreByIdQuery query = new GetGenreByIdQuery(_context, _mapper);
            query.GenreId = id;
            GetGenreByIdValidator validator = new GetGenreByIdValidator();
            validator.ValidateAndThrow(query);

            var genreObj = query.Handle();

            return Ok(genreObj);

        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = newGenre;
            CreateGenreValidator validator = new CreateGenreValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updatedGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = id;
            command.Model = updatedGenre;
            UpdateGenreValidator validator = new UpdateGenreValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;
            DeleteGenreValidator validator = new DeleteGenreValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }

}
