using System.Collections.Generic;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Core.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(int id);
        void Add(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}