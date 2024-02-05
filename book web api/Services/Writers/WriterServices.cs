using book.Entitis;
using book.EntitisMaps;
using book_web_api.Services.Writers.WriterDto;
using Microsoft.EntityFrameworkCore;

namespace book_web_api.Services.Writers
{
    public class WriterServices
    {
        EFDBContext _context = new EFDBContext();
        public void AddWriter(AddWriterDTo dto)
        {
            var writer = new Writer();
            writer.Name = dto.Name;
            _context.Writers.Add(writer);
            _context.SaveChanges();
        }
        public void UpdateWriter(int id, UpdateWriterDto dto)
        {
            var writer = _context.Writers.Find(id);
            if (writer == null)
            {
                throw new Exception("writer not found");
            }
            writer.Name = dto.Name;
            _context.SaveChanges();

        }
        public void DeleteWriter(int id)
        {
            var writer = _context.Writers.Find(id);
            if (writer == null)
            {
                throw new Exception("writer not found");
            }
            _context.Writers.Remove(writer);
            _context.SaveChanges();
        }
        public List<Writer> GetWriter()
        {
           return _context .Writers.Include(_=>_.Books).ToList();
        }
    }
}
