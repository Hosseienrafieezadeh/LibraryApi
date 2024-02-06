using book_web_api.Services.Books.BooksDto;
using book_web_api.Services.Books;
using Microsoft.AspNetCore.Mvc;
using book.Entitis;
using System.Collections.Generic;

namespace book_web_api.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly BooksServices _bookService;

        public BookController(BooksServices bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] AddBookDto dto)
        {
            _bookService.AddBook(dto);
            return Ok();
        }

        [HttpPatch("update-book/{name}")]
        public IActionResult UpdateBook(string name, [FromBody] UpdateBookDto dto)
        {
            _bookService.UpdateBook(name, dto);
            return Ok();
        }

        [HttpDelete("delete-book/{name}")]
        public IActionResult DeleteBook(string name)
        {
            _bookService.DeleteBook(name);
            return Ok();
        }

        [HttpGet("get-book")]
        public IActionResult GetBook()
        {
            var books = _bookService.GetBooks();
            return Ok(books);
        }
    }
}
