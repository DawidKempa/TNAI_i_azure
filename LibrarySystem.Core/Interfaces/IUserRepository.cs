using LibrarySystem.Core.Models;

namespace LibrarySystem.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        bool EmailExists(string email);
    }
}