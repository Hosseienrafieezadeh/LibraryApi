using book.Entitis;
using book.EntitisMaps;
using book_web_api.Services.Writers.WriterDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace book_web_api.Services.Writers
{
    public class WriterServices
    {
        private readonly EFDBContext _context;

        public WriterServices(EFDBContext context)
        {
            _context = context;
        }

        public void AddWriter(AddWriterDTo dto)
        {
            var writer = new Writer
            {
                Name = dto.Name
            };

            _context.Writers.Add(writer);
            _context.SaveChanges();
        }

        public void UpdateWriter(string name, UpdateWriterDto dto)
        {
            var writer = _context.Writers.FirstOrDefault(w => w.Name == name);
            if (writer == null)
            {
                throw new Exception("Writer not found.");
            }

            writer.Name = dto.Name;
            _context.SaveChanges();
        }

        public void DeleteWriter(string name)
        {
            var writer = _context.Writers.FirstOrDefault(w => w.Name == name);
            if (writer == null)
            {
                throw new Exception("Writer not found.");
            }

            _context.Writers.Remove(writer);
            _context.SaveChanges();
        }

        public List<Writer> GetWriters()
        {
            return _context.Writers.Include(w => w.Books).ToList();
        }
    }
}
