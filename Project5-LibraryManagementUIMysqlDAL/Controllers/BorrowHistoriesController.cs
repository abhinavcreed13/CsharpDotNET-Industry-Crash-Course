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
    public class BorrowHistoriesController : Controller
    {
        DataTable allCustomers;
        DataTable borrowHistoriesData;
        // GET: BorrowHistories
        public ActionResult Index()
        {
            MySQLDALManager manager = new MySQLDALManager("mysqlConnKey");
            borrowHistoriesData = manager.ExecuteStoredProcedure("GetAllBorrowHistories");
            TempData["borrowHistories"] = borrowHistoriesData;
            List<BorrowHistory> borrowHistories = new List<BorrowHistory>();

            foreach(DataRow dr in borrowHistoriesData.Rows)
            {
                borrowHistories.Add(new BorrowHistory
                {
                    BookId = dr.Field<int>("BookId"),
                    CustomerId = dr.Field<int>("CustomerId"),
                    BorrowDate = dr.Field<DateTime>("BorrowDate"),
                    ReturnDate = dr.Field<DateTime?>("ReturnDate"),
                    BookTitle = dr.Field<string>("Title"),
                    CustomerName = dr.Field<string>("Name")
                });
            }
            return View(borrowHistories);
        }

        // GET: BorrowHistories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BorrowHistories/Create
        public ActionResult Create(int id)
        {
            // list of customers
            if (TempData["allCustomers"] == null)
            {
                //fetch
                MySQLDALManager manager = new MySQLDALManager("mysqlConnKey");
                allCustomers = manager.ExecuteStoredProcedure("GetAllCustomers");
            }
            else
            {
                allCustomers = TempData["allCustomers"] as DataTable;
            }
            List<Customer> customers = new List<Customer>();
            foreach (DataRow dr in allCustomers.Rows)
            {
                customers.Add(new Customer
                {
                    CustomerId = dr.Field<int>("CustomerId"),
                    Name = dr.Field<string>("Name"),
                    Address = dr.Field<string>("Address"),
                    Contact = dr.Field<string>("Contact")
                });
            }
            var borrowHistory = new BorrowHistory
            {
                BookId = id,
                BorrowDate = DateTime.Now
            };
            //Dropdown list
            ViewBag.Customers = customers;
            return View(borrowHistory);
        }

        // POST: BorrowHistories/Create
        [HttpPost]
        public ActionResult Create(BorrowHistory borrowHistory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MySQLDALManager manager = new MySQLDALManager("mysqlConnKey");
                    List<MySqlParameter> param = new List<MySqlParameter>
                    {
                        new MySqlParameter("book_id",borrowHistory.BookId),
                        new MySqlParameter("customer_id",borrowHistory.CustomerId),
                        new MySqlParameter("borrow_date",borrowHistory.BorrowDate)
                    };
                    manager.ExecuteStoredProcedure("BorrowBook", param);
                    return RedirectToAction("Index");
                }
                return View(borrowHistory);
            }
            catch
            {
                return View(borrowHistory);
            }
        }

        // GET: BorrowHistories/Edit/5
        public ActionResult Edit(int id)
        {
            if (TempData["borrowHistories"] == null)
            {
                MySQLDALManager mysqlManager = new MySQLDALManager("mysqlConnKey");
                borrowHistoriesData = mysqlManager.ExecuteStoredProcedure("GetAllBorrowHistories");
                TempData["borrowHistories"] = borrowHistoriesData;
            }
            else
            {
                borrowHistoriesData = TempData["borrowHistories"] as DataTable;
            }
            //LINQ
            var targetRow = borrowHistoriesData.AsEnumerable().
                Where(row => row.Field<int>("BookId") == id &&
                row.Field<DateTime?>("ReturnDate") == null).FirstOrDefault();
            if (targetRow == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var borrowHistory = new BorrowHistory
            {
                BorrowHistoryId = targetRow.Field<int>("BorrowHistoryId"),
                BookId = targetRow.Field<int>("BookId"),
                CustomerId = targetRow.Field<int>("CustomerId"),
                BorrowDate = targetRow.Field<DateTime>("BorrowDate"),
                BookTitle = targetRow.Field<string>("Title"),
                CustomerName = targetRow.Field<string>("Name")
            };
            return View(borrowHistory);
        }

        // POST: BorrowHistories/Edit/5
        [HttpPost]
        public ActionResult Edit(BorrowHistory borrowHistory)
        {
            try
            {
                MySQLDALManager manager = new MySQLDALManager("mysqlConnKey");
                List<MySqlParameter> param = new List<MySqlParameter>
                {
                    new MySqlParameter("borrow_history_id", borrowHistory.BorrowHistoryId)
                };
                manager.ExecuteStoredProcedure("ReturnBook", param);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: BorrowHistories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BorrowHistories/Delete/5
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
