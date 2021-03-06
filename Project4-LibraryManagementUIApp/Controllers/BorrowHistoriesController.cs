﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Session3_LibraryManagementUIApp.DAL;
using Session3_LibraryManagementUIApp.Models;

namespace Session4_LibraryManagementUIApp.Controllers
{
    public class BorrowHistoriesController : Controller
    {
        private LibraryDBContext db = new LibraryDBContext();

        // GET: BorrowHistories
        public ActionResult Index()
        {
            var borrowHistories = db.BorrowHistories.Include(b => b.Book).Include(b => b.Customer);
            return View(borrowHistories.ToList());
        }

        // GET: BorrowHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowHistory borrowHistory = db.BorrowHistories.Find(id);
            if (borrowHistory == null)
            {
                return HttpNotFound();
            }
            return View(borrowHistory);
        }

        // GET: BorrowHistories/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var borrowHistory = new BorrowHistory
            {
                BookId = book.BookId,
                BorrowDate = DateTime.Now,
                Book = book
            };
            //ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            ViewBag.Customers = db.Customers;
            return View(borrowHistory);
        }

        // POST: BorrowHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BorrowHistoryId,BookId,CustomerId,BorrowDate,ReturnDate")] BorrowHistory borrowHistory)
        {
            if (ModelState.IsValid)
            {
                db.BorrowHistories.Add(borrowHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", borrowHistory.BookId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", borrowHistory.CustomerId);
            return View(borrowHistory);
        }

        // GET: BorrowHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //BorrowHistory borrowHistory = db.BorrowHistories.Find(id);
            BorrowHistory borrowHistory = db.BorrowHistories
                .Include(b => b.Book)
                .Include(c => c.Customer)
                .Where(b => b.BookId == id && b.ReturnDate == null)
                .FirstOrDefault();
            if (borrowHistory == null)
            {
                return HttpNotFound();
            }
            //ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", borrowHistory.BookId);
            //ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", borrowHistory.CustomerId);
            return View(borrowHistory);
        }

        // POST: BorrowHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            //ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", borrowHistory.BookId);
            //ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", borrowHistory.CustomerId);
            return View(borrowHistory);
        }

        // GET: BorrowHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowHistory borrowHistory = db.BorrowHistories.Find(id);
            if (borrowHistory == null)
            {
                return HttpNotFound();
            }
            return View(borrowHistory);
        }

        // POST: BorrowHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BorrowHistory borrowHistory = db.BorrowHistories.Find(id);
            db.BorrowHistories.Remove(borrowHistory);
            db.SaveChanges();
            return RedirectToAction("Index");
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
