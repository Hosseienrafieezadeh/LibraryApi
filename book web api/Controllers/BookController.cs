using book_web_api.Services.Books.BooksDto;
using book_web_api.Services.Books;
using Microsoft.AspNetCore.Mvc;
using book.Entitis;

namespace book_web_api.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController
    {
        BooksServices _bookService = new BooksServices();
        [HttpPost("add-book")]
        public void AddBook([FromBody] AddBookDto dto)
        {
            _bookService.AddBook(dto);
        }
        [HttpPatch("update-book{id}")]
        public void UpdateBook([FromRoute] int id, [FromBody] UpdateBookDto dto)
        {
            _bookService.UpdateBook(id, dto);

        }
        [HttpDelete("delete-book/{id}")]
        public void DeleteBook([FromRoute] int id)
        {
            _bookService.DeleteBook(id);
        }
        [HttpGet("Get-book")]
        public List<Book> GetBook()
        {

            return _bookService.GetBook();

        }
    }
}
