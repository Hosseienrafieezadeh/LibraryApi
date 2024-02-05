using book.Entitis;
using book.EntitisMaps;
using book_web_api.Services.Shelfs.ShelfsDto;
using Microsoft.EntityFrameworkCore;

namespace book_web_api.Services.Shelfs
{
    public class ShelfServices
    {
        EFDBContext _context = new EFDBContext();
        public void AddShelf(AddShelfDto dto)
        {
            var shelf = new Shelf();
            shelf.Title = dto.Title;
            _context.Shelves.Add(shelf);
            _context.SaveChanges();
        }
        public void DeleteShelfs(int id)
        {
            var shelf = _context.Shelves.Find(id);
            if (shelf is null)
            {
                throw new Exception("Genre not existed");
            }
            _context.Shelves.Remove(shelf);
            _context.SaveChanges();
        }
        public void UpdateBook(int id, UpdateShelfDto dto)
        {
            var shelf = _context.Shelves.Find(id);
            if (shelf is null)
            {
                throw new Exception("Genre not existed");
            }
            shelf.Title = dto.Title;
            _context.SaveChanges();
        }
        public List<Shelf> GetShelfs()
        {
          return _context.Shelves.Include(_=>_.Books).ToList();
        }
    }
}
