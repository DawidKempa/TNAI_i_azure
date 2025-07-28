using System.Collections.Generic;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Core.Interfaces
{
    public interface ILoanRepository
    {
        List<Loan> GetAll();
        Loan GetById(int id);
        void Add(Loan loan);
        void Update(Loan loan);
        List<Loan> GetActiveLoans();
    }
}