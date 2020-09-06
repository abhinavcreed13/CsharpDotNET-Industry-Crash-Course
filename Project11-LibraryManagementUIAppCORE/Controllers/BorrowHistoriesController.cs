using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project11_LibraryManagementUIAppCORE.DAL;
using Project11_LibraryManagementUIAppCORE.Models;

namespace Project11_LibraryManagementUIAppCORE.Controllers
{
    public class BorrowHistoriesController : Controller
    {
        private readonly LibraryDbContext _context;

        public BorrowHistoriesController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: BorrowHistories
        public async Task<IActionResult> Index()
        {
            var libraryDbContext = _context.BorrowHistories.Include(b => b.Book).Include(b => b.Customer);
            return View(await libraryDbContext.ToListAsync());
        }

        // GET: BorrowHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowHistory = await _context.BorrowHistories
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BorrowHistoryId == id);
            if (borrowHistory == null)
            {
                return NotFound();
            }

            return View(borrowHistory);
        }

        // GET: BorrowHistories/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status405MethodNotAllowed);
            }
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            var borrowHistory = new BorrowHistory
            {
                BookId = book.BookId,
                BorrowDate = DateTime.Now,
                Book = book
            };
            //ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            //ViewBag.Customers = _context.Customers;
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Name");
            return View(borrowHistory);
            //ViewData["BookId"] = new SelectList(_context.Books, "BookId", "SerialNumber");
            //return View();
        }

        // POST: BorrowHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowHistoryId,BookId,CustomerId,BorrowDate,ReturnDate")] BorrowHistory borrowHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrowHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["BookId"] = new SelectList(_context.Books, "BookId", "SerialNumber", borrowHistory.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Name", borrowHistory.CustomerId);
            return View(borrowHistory);
        }

        // GET: BorrowHistories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status405MethodNotAllowed);
            }
            //BorrowHistory borrowHistory = db.BorrowHistories.Find(id);
            BorrowHistory borrowHistory = _context.BorrowHistories
                .Include(b => b.Book)
                .Include(c => c.Customer)
                .Where(b => b.BookId == id && b.ReturnDate == null)
                .FirstOrDefault();
            if (borrowHistory == null)
            {
                return NotFound();
            }
            //ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", borrowHistory.BookId);
            //ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", borrowHistory.CustomerId);
            return View(borrowHistory);
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var borrowHistory = await _context.BorrowHistories.FindAsync(id);
            //if (borrowHistory == null)
            //{
            //    return NotFound();
            //}
            //ViewData["BookId"] = new SelectList(_context.Books, "BookId", "SerialNumber", borrowHistory.BookId);
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Address", borrowHistory.CustomerId);
            //return View(borrowHistory);
        }

        // POST: BorrowHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowHistoryId,BookId,CustomerId,BorrowDate,ReturnDate")] BorrowHistory borrowHistory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    borrowHistory.ReturnDate = DateTime.Now;
                    _context.Update(borrowHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowHistoryExists(borrowHistory.BorrowHistoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["BookId"] = new SelectList(_context.Books, "BookId", "SerialNumber", borrowHistory.BookId);
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Address", borrowHistory.CustomerId);
            return View(borrowHistory);
        }

        // GET: BorrowHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowHistory = await _context.BorrowHistories
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BorrowHistoryId == id);
            if (borrowHistory == null)
            {
                return NotFound();
            }

            return View(borrowHistory);
        }

        // POST: BorrowHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrowHistory = await _context.BorrowHistories.FindAsync(id);
            _context.BorrowHistories.Remove(borrowHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowHistoryExists(int id)
        {
            return _context.BorrowHistories.Any(e => e.BorrowHistoryId == id);
        }
    }
}
