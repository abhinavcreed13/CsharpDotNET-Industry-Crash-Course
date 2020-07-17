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
    public class CustomersController : Controller
    {
        DataTable allCustomers;
        // GET: Customers
        public ActionResult Index()
        {
            MySQLDALManager manager = new MySQLDALManager("mysqlConnKey");
            try
            {
                allCustomers = manager.ExecuteStoredProcedure("GetAllCustomers");
                TempData["allCustomers"] = allCustomers;
            }
            catch (Exception ex)
            {
                allCustomers = new DataTable();
            }
            List<Customer> customers = new List<Customer>();
            foreach(DataRow dr in allCustomers.Rows)
            {
                customers.Add(new Customer
                {
                    CustomerId = dr.Field<int>("CustomerId"),
                    Name = dr.Field<string>("Name"),
                    Address = dr.Field<string>("Address"),
                    Contact = dr.Field<string>("Contact")
                });
            }
            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            if (TempData["allCustomers"] == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
            }
            allCustomers = TempData["allCustomers"] as DataTable;
            var detailRow = allCustomers.AsEnumerable()
                .Where(row => row.Field<int>("CustomerId") == id)
                .FirstOrDefault();
            if (detailRow == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = new Customer
            {
                CustomerId = detailRow.Field<int>("CustomerId"),
                Name = detailRow.Field<string>("Name"),
                Address = detailRow.Field<string>("Address"),
                Contact = detailRow.Field<string>("Contact")
            };
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
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

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
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

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
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
