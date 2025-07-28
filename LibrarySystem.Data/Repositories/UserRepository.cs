using System.Linq;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using LibrarySystem.Data;

namespace LibrarySystem.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryContext _context;

        public UserRepository(LibraryContext context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public bool EmailExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}