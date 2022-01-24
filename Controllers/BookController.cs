using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.DeleteBook;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.UpdateBook;
using BookStore.DBOperations;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class BookController : Controller
    {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery getBooks = new GetBooksQuery(_context);
            return Ok(getBooks.Handle());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                GetBookById getBookById = new GetBookById(_context);
                return Ok(getBookById.Handle(id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand createBook = new CreateBookCommand(_context);
            try
            {
                createBook.Model = newBook;
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
            try
            {
                updateBook.Model = changeBook;
                updateBook.Handle(id);
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
            try
            {
                DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
                deleteBookCommand.Handle(id);
                return Ok();
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
