using System.Collections.Generic;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public void AddBook(Book book)
        {
            _bookRepository.Add(book);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }

        public List<Book> GetAvailableBooks()
        {
            var books = _bookRepository.GetAll();
            return books.FindAll(b => b.IsAvailable);
        }
    }
}