using AutoMapper;
using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.DeleteBook;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.UpdateBook;
using BookStore.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class BookController : Controller
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery getBooks = new GetBooksQuery(_context, _mapper);
            return Ok(getBooks.Handle());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookById getBookById = new GetBookById(_context, _mapper);
            GetBookByIdValidator validationRules = new GetBookByIdValidator();
            try
            {
                getBookById.BookId = id;
                validationRules.ValidateAndThrow(getBookById);
                return Ok(getBookById.Handle());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand createBook = new CreateBookCommand(_context, _mapper);
            CreateBookCommandValidator validationRules = new CreateBookCommandValidator();

            try
            {
                createBook.Model = newBook;
                validationRules.ValidateAndThrow(createBook);
                createBook.Handle();
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel changeBook)
        {
            UpdateBookCommand updateBook = new UpdateBookCommand(_context);
            UpdateBookCommandValidator validationRules = new UpdateBookCommandValidator();
            try
            {
                updateBook.Model = changeBook;
                updateBook.BookId = id;
                validationRules.ValidateAndThrow(updateBook);
                updateBook.Handle();
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
            DeleteBookCommandValidator validationRules = new DeleteBookCommandValidator();
            try
            {
                deleteBookCommand.BookId = id;
                validationRules.ValidateAndThrow(deleteBookCommand);
                deleteBookCommand.Handle();
                return Ok();
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
