using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Data.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly LibraryContext _context;

        public ReaderRepository(LibraryContext context)
        {
            _context = context;
        }

        public List<Reader> GetAll()
        {
            return _context.Readers.ToList();
        }

        public Reader GetById(int id)
        {
            return _context.Readers.Find(id);
        }

        public void Add(Reader reader)
        {
            _context.Readers.Add(reader);
            _context.SaveChanges();
        }

        public void Update(Reader reader)
        {
            _context.Readers.Update(reader);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var reader = _context.Readers.Find(id);
            if (reader != null)
            {
                _context.Readers.Remove(reader);
                _context.SaveChanges();
            }
        }
    }
}