using BookStore.BookOperations.CreateBook;
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
            return Ok(getBooks.Handler());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookById getBookById = new GetBookById(_context);
            return Ok(getBookById.Handler(id));
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand createBook = new CreateBookCommand(_context);
            try
            {
            createBook.Model = newBook;
            createBook.Handle();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel changeBook)
        {
            UpdateBookCommand updateBook = new UpdateBookCommand(_context);
            try
            {
                updateBook.Model = changeBook;
                updateBook.Handle(id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(xbook => xbook.Id == id);
            if (book is null)
            {
                return BadRequest();
            }
            else
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Ok();
            }
        }

    }
}
