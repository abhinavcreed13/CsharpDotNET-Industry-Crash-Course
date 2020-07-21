using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Session8_LibraryManagementUIMysqlEF6.DAL;
using Session8_LibraryManagementUIMysqlEF6.Models;

namespace Session8_LibraryManagementUIMysqlEF6.Controllers
{
    public class BorrowHistoriesController : Controller
    {
        private LibraryDBContext db = new LibraryDBContext();

        // GET: BorrowHistories
        public ActionResult Index()
        {
            var borrowHistories = db.BorrowHistories
                .Include(b => b.Book)
                .Include(b => b.Customer);
            return View(borrowHistories.ToList());
        }


        // GET: BorrowHistories/Create
        public ActionResult Create(int id)
        {
            Book book = db.Books.Find(id);
            var borrowHistory = new BorrowHistory
            {
                BookId = id,
                Book = book,
                BorrowDate = DateTime.Now
            };
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            return View(borrowHistory);
        }

        // POST: BorrowHistories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,CustomerId,BorrowDate")] BorrowHistory borrowHistory)
        {
            if (ModelState.IsValid)
            {
                db.BorrowHistories.Add(borrowHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", borrowHistory.CustomerId);
            return View(borrowHistory);
        }

        // GET: BorrowHistories/Edit/5
        public ActionResult Edit(int id)
        {
            var histories = db.BorrowHistories.Include(b => b.Book).Include(b => b.Customer);
            var borrowHistoryObj = histories.Where(history => history.BookId == id
                && history.ReturnDate == null).FirstOrDefault();
            if (borrowHistoryObj == null)
            {
                return HttpNotFound();
            }
            return View(borrowHistoryObj);
        }

        // POST: BorrowHistories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BorrowHistoryId,BookId,CustomerId,BorrowDate,ReturnDate")] BorrowHistory borrowHistory)
        {
            if (ModelState.IsValid)
            {
                borrowHistory.ReturnDate = DateTime.Now;
                db.Entry(borrowHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(borrowHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
