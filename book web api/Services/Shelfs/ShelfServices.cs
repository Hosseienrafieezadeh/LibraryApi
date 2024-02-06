using book.Entitis;
using book.EntitisMaps;
using book_web_api.Services.Shelfs.ShelfsDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace book_web_api.Services.Shelfs
{
    public class ShelfServices
    {
        private readonly EFDBContext _context;

        public ShelfServices(EFDBContext context)
        {
            _context = context;
        }

        public void AddShelf(AddShelfDto dto)
        {
            var shelf = new Shelf
            {
                Title = dto.Title
            };

            _context.Shelves.Add(shelf);
            _context.SaveChanges();
        }

        public void DeleteShelf(string name)
        {
            var shelf = _context.Shelves.Find(name);
            if (shelf == null)
            {
                throw new Exception("Shelf not found.");
            }

            _context.Shelves.Remove(shelf);
            _context.SaveChanges();
        }

        public void UpdateShelf(string name, UpdateShelfDto dto)
        {
            var shelf = _context.Shelves.Find(name);
            if (shelf == null)
            {
                throw new Exception("Shelf not found.");
            }

            shelf.Title = dto.Title;
            _context.SaveChanges();
        }

        public List<Shelf> GetShelves()
        {
            return _context.Shelves.Include(s => s.Books).ToList();
        }
    }
}
