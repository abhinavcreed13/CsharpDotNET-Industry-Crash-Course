using Session2_DataAccessLayer;
using Session2_PhonebookWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session2_PhonebookWebApp.Controllers
{
    public class HomeController : Controller
    {
        public void OnPost()
        {
            string userName = Request.Form["UserName"].ToString();
        }

        public ActionResult Index()
        {
            //Replace this data with SQL server
            SQLDALManager manager = new SQLDALManager("dbConnString");

            DataTable data = manager.ExecuteStoredProcedure("getAllUsers");

            List<UserData> allUsers = new List<UserData>();

            foreach (DataRow dr in data.Rows)
            {
                allUsers.Add(new UserData
                {
                    UserId = Convert.ToInt32(dr["user_id"]),
                    UserName = dr["user_name"].ToString()
                });
            }

            //get contacts for all users
            List<UserPhoneBook> completePhoneBook = new List<UserPhoneBook>();
            foreach (UserData user in allUsers)
            {
                int targetUserId = user.UserId;
                DataTable contacts = manager.ExecuteStoredProcedure("getContactNamesForUser",
                    new List<SqlParameter> {
                        new SqlParameter("@userId",targetUserId)
                    });
                UserPhoneBook phonebook = new UserPhoneBook()
                {
                    User = user,
                    Contacts = new List<UserData>()
                };
                foreach (DataRow dr in contacts.Rows)
                {
                    phonebook.Contacts.Add(new UserData
                    {
                        UserId = Convert.ToInt32(dr["user_id"]),
                        UserName = dr["user_name"].ToString()
                    });
                }
                completePhoneBook.Add(phonebook);
            }


            // Dummy data
            //List<UserData> allUsers = new List<UserData>
            //{
            //    new UserData {UserId = 1, UserName = "Alice"},
            //    new UserData {UserId = 2, UserName = "Bob"},
            //    new UserData {UserId = 3, UserName = "Micheal"}
            //};

            //List<UserPhoneBook> completePhoneBook = new List<UserPhoneBook>
            //{
            //    new UserPhoneBook
            //    {
            //        User = allUsers[0],
            //        Contacts = new List<UserData>{ allUsers[1], allUsers[2] }
            //    }
            //};

            UserModel model = new UserModel
            {
                users = allUsers,
                phonebook = completePhoneBook,
                UserObject = new UserData()
            };

            //weakly typed data pass
            ViewData["homeText"] = "Phonebook UI page";

            //strongly typed data pass
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Create(UserData data)
        {
            SQLDALManager manager = new SQLDALManager("dbConnString");
            manager.ExecuteStoredProcedure("addUser", new List<SqlParameter>
            {
                new SqlParameter("@userName",data.UserName)
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(UserData data)
        {
            SQLDALManager manager = new SQLDALManager("dbConnString");
            manager.ExecuteStoredProcedure("updateUserData", new List<SqlParameter>
            {
                new SqlParameter("@newUserName",data.UserName),
                new SqlParameter("@userId",data.UserId)
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(UserData data)
        {
            SQLDALManager manager = new SQLDALManager("dbConnString");
            manager.ExecuteStoredProcedure("deleteUserData", new List<SqlParameter>
            {
                new SqlParameter("@userId",data.UserId)
            });
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}