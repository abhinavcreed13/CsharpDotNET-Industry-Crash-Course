using MySql.Data.MySqlClient;
using Session2_DataAccessLayer;
using Session6_LibraryManagementUIMysqlDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session6_LibraryManagementUIMysqlDAL.Controllers
{
    public class BooksController : Controller
    {
        DataTable allBooks;
        DataTable borrowHistories;

        // GET: Books
        public ActionResult Index()
        {
            MySQLDALManager mysqlManager = new MySQLDALManager("mysqlConnKey");
            try
            {
                allBooks = mysqlManager.ExecuteStoredProcedure("GetAllBooks");
                TempData["allBooks"] = allBooks;
                borrowHistories = mysqlManager.ExecuteStoredProcedure("GetAllBorrowHistories");
                TempData["borrowHistories"] = borrowHistories;
            }
            catch (Exception ex)
            {
                allBooks = new DataTable();
                borrowHistories = new DataTable();
            }
            List<Book> books = new List<Book>();
            foreach (DataRow dr in allBooks.Rows)
            {
                Book bookRecord = new Book
                {
                    BookId = Convert.ToInt32(dr["BookId"]),
                    Title = dr["Title"].ToString(),
                    SerialNumber = dr["SerialNumber"].ToString(),
                    Author = dr["Author"].ToString(),
                    Publisher = dr["Publisher"].ToString()
                };
                //get availability
                var bookId = dr.Field<int>("BookId");
                var availability = !borrowHistories.AsEnumerable()
                    .Any(row => row.Field<int>("BookId") == bookId &&
                    row.Field<DateTime?>("ReturnDate") == null);
                bookRecord.IsAvailable = availability;
                books.Add(bookRecord);
            }
            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            // LINQ
            //if (allBooks == null)
            //{
            //    if (TempData["allBooks"] == null)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        allBooks = TempData["allBooks"] as DataTable;
            //    }
            //}
            //// select * from book where BookId = id
            //DataRow bookIdRow = allBooks.AsEnumerable()
            //    .Where(x => x.Field<int>("BookId") == id)
            //    .FirstOrDefault();
            //if (bookIdRow == null)
            //{
            //    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            //}

            //Get from mysql
            MySQLDALManager mysqlManager = new MySQLDALManager("mysqlConnKey");
            List<MySqlParameter> param = new List<MySqlParameter>
            {
                new MySqlParameter("book_id",id)
            };
            DataRow bookIdRow = mysqlManager.ExecuteStoredProcedure("GetBook", param).Rows[0];
            Book foundBook = new Book
            {
                BookId = bookIdRow.Field<int>("BookId"),
                Title = bookIdRow.Field<string>("Title"),
                SerialNumber = bookIdRow["SerialNumber"].ToString(),
                Author = bookIdRow["Author"].ToString(),
                Publisher = bookIdRow["Publisher"].ToString()
            };
            return View(foundBook);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
