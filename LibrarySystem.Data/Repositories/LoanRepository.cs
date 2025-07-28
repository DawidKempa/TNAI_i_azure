using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Data.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryContext _context;

        public LoanRepository(LibraryContext context)
        {
            _context = context;
        }

        public List<Loan> GetAll()
        {
            return _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Reader)
                .ToList();
        }

        public Loan GetById(int id)
        {
            return _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Reader)
                .FirstOrDefault(l => l.Id == id);
        }

        public void Add(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }

        public void Update(Loan loan)
        {
            _context.Loans.Update(loan);
            _context.SaveChanges();
        }

        public List<Loan> GetActiveLoans()
        {
            return _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Reader)
                .Where(l => l.ReturnDate == null)
                .ToList();
        }
    }
}