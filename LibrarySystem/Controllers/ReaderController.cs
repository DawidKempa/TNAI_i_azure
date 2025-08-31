using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Core.Models;
using LibrarySystem.Services;

namespace LibrarySystem.Controllers
{
    [Authorize]
    public class ReadersController : Controller
    {
        private readonly ReaderService _readerService;

        public ReadersController(ReaderService readerService)
        {
            _readerService = readerService;
        }

        public IActionResult Index()
        {
            var readers = _readerService.GetAllReaders();
            return View(readers);
        }

        public IActionResult Details(int id)
        {
            var reader = _readerService.GetReaderById(id);
            if (reader == null)
                return NotFound();
            return View(reader);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reader reader)
        {
            if (ModelState.IsValid)
            {
                _readerService.AddReader(reader);
                return RedirectToAction(nameof(Index));
            }
            return View(reader);
        }

        public IActionResult Edit(int id)
        {
            var reader = _readerService.GetReaderById(id);
            if (reader == null)
                return NotFound();
            return View(reader);
        }

        [HttpPost]
        public IActionResult Edit(Reader reader)
        {
            if (ModelState.IsValid)
            {
                _readerService.UpdateReader(reader);
                return RedirectToAction(nameof(Index));
            }
            return View(reader);
        }

        public IActionResult Delete(int id)
        {
            var reader = _readerService.GetReaderById(id);
            if (reader == null)
                return NotFound();
            return View(reader);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _readerService.DeleteReader(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
