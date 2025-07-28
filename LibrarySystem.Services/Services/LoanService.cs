using System;
using System.Collections.Generic;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Services
{
    public class LoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;

        public LoanService(ILoanRepository loanRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
        }

        public List<Loan> GetAllLoans()
        {
            return _loanRepository.GetAll();
        }

        public List<Loan> GetActiveLoans()
        {
            return _loanRepository.GetActiveLoans();
        }

        public bool BorrowBook(int bookId, int readerId)
        {
            var book = _bookRepository.GetById(bookId);
            if (book == null || !book.IsAvailable)
                return false;

            var loan = new Loan
            {
                BookId = bookId,
                ReaderId = readerId,
                LoanDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(14)
            };

            _loanRepository.Add(loan);
            
            book.IsAvailable = false;
            _bookRepository.Update(book);

            return true;
        }

        public bool ReturnBook(int loanId)
        {
            var loan = _loanRepository.GetById(loanId);
            if (loan == null || loan.ReturnDate != null)
                return false;

            loan.ReturnDate = DateTime.UtcNow;
            _loanRepository.Update(loan);

            var book = _bookRepository.GetById(loan.BookId);
            book.IsAvailable = true;
            _bookRepository.Update(book);

            return true;
        }
    }
}