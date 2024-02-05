using book.Entitis;
using book.EntitisMaps;
using book_web_api.Services.Books.BooksDto;
using book_web_api.Services.Writers.WriterDto;
using Microsoft.EntityFrameworkCore;

namespace book_web_api.Services.Books
{
    public class BooksServices
    {
        EFDBContext _context = new EFDBContext();
        public void AddBook(AddBookDto dto)
        {
            var book = new Book();
            book.Name = dto.Name;
            book.WriterId = dto.WriterId;
            book.ShelfId = dto.ShelfId;
            book.DateOfRelease = dto.DateOfRelease;
            book.Inventory = dto.Inventory;
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void UpdateBook(int id, UpdateBookDto dto)
        {
            var book = _context.Books.Find(id);
            if (book is null)
            {
                throw new Exception("book not found");
            }
            book.Name = dto.Name;
            book.WriterId = dto.WriterId;
            book.ShelfId = dto.ShelfId;
            book.Inventory = dto.Inventory;
            book.DateOfRelease = dto.DateOfRelease;
            _context.Books.Update(book);
            _context.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book is null)
            {
                throw new Exception("book not found");
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
        public List<Book> GetBook()
        {
          return _context.Books.Include(_=>_.Rents).ToList();
        }
    }
}
