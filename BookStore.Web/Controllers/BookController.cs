using BookStore.Data.Entities;
using BookStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository) 
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var listBooks = _bookRepository.GetAllBooks();
            return View(listBooks);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _bookRepository.AddBook(book);
            return RedirectToAction("Index");
        }

        [Route("book/id")]
        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetBookDetails(id);
            return View(book);
        }
    }
}
