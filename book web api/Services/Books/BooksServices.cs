using book.Entitis;
using book.EntitisMaps;
using book_web_api.Services.Books.BooksDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace book_web_api.Services.Books
{
    public class BooksServices
    {
        private readonly EFDBContext _context;

        public BooksServices(EFDBContext context)
        {
            _context = context;
        }

        public void AddBook(AddBookDto dto)
        {
            var book = new Book
            {
                Name = dto.Name,
                WriterId = dto.WriterId,
                ShelfId = dto.ShelfId,
                DateOfRelease = dto.DateOfRelease,
                Inventory = dto.Inventory
            };

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(string name, UpdateBookDto dto)
        {
            var book = _context.Books.FirstOrDefault(b => b.Name == name);
            if (book == null)
            {
                throw new Exception("Book not found");
            }

            book.Name = dto.Name;
            book.WriterId = dto.WriterId;
            book.ShelfId = dto.ShelfId;
            book.Inventory = dto.Inventory;
            book.DateOfRelease = dto.DateOfRelease;

            _context.SaveChanges();
        }

        public void DeleteBook(string name)
        {
            var book = _context.Books.FirstOrDefault(b => b.Name == name);
            if (book == null)
            {
                throw new Exception("Book not found");
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public List<Book> GetBooks()
        {
            return _context.Books.Include(b => b.Rents).ToList();
        }
    }
}
