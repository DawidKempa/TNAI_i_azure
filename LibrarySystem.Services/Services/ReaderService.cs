using System.Collections.Generic;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Services
{
    public class ReaderService
    {
        private readonly IReaderRepository _readerRepository;

        public ReaderService(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        public List<Reader> GetAllReaders()
        {
            return _readerRepository.GetAll();
        }

        public Reader GetReaderById(int id)
        {
            return _readerRepository.GetById(id);
        }

        public void AddReader(Reader reader)
        {
            _readerRepository.Add(reader);
        }

        public void UpdateReader(Reader reader)
        {
            _readerRepository.Update(reader);
        }

        public void DeleteReader(int id)
        {
            _readerRepository.Delete(id);
        }
    }
}
