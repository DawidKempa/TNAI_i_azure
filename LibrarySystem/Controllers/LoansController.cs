using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibrarySystem.Services;
using LibrarySystem.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;


namespace LibrarySystem.Controllers
{
    [Authorize]
    public class LoansController : Controller
    {
        private readonly LoanService _loanService;
        private readonly BookService _bookService;
        private readonly IReaderRepository _readerRepository;

        public LoansController(LoanService loanService, BookService bookService, IReaderRepository readerRepository)
        {
            _loanService = loanService;
            _bookService = bookService;
            _readerRepository = readerRepository;
        }

        public IActionResult Index()
        {
            var loans = _loanService.GetAllLoans();
            return View(loans);
        }

        public IActionResult Create()
        {
            ViewBag.Books = new SelectList(_bookService.GetAvailableBooks(), "Id", "Title");
            ViewBag.Readers = new SelectList(_readerRepository.GetAll(), "Id", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(int bookId, int readerId)
        {
            if (_loanService.BorrowBook(bookId, readerId))
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Nie można wypożyczyć książki");
            ViewBag.Books = new SelectList(_bookService.GetAvailableBooks(), "Id", "Title");
            ViewBag.Readers = new SelectList(_readerRepository.GetAll(), "Id", "LastName");
            return View();
        }

        [HttpPost]
        public IActionResult Return(int id)
        {
            _loanService.ReturnBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
}