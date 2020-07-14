using Session3_LibraryManagementUIApp.DAL;
using Session3_LibraryManagementUIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session3_LibraryManagementUIApp.Controllers
{
    public class SelfBooksController : Controller
    {
        private LibraryDBContext db = new LibraryDBContext();

        // GET: SelfBooks
        public ActionResult Index()
        {
            List<Book> books = db.Books.ToList();
            return View(books);
        }


        //GET: Books/Create
        public ActionResult CreateAction()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult CreateAction(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", book);
        }

        public ActionResult DetailsAction(int? bookId)
        {
            if (bookId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(bookId);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View("Details", book);
        }
    }
}