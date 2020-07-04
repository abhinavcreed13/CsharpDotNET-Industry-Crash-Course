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
    public class PhoneBookController : Controller
    {
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

            UserModel model = new UserModel
            {
                users = allUsers,
                phonebook = completePhoneBook,
                UserObject = new UserData()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserPhoneBookDB data)
        {
            SQLDALManager manager = new SQLDALManager("dbConnString");
            manager.ExecuteStoredProcedure("addUserPhonebook", new List<SqlParameter>
            {
                new SqlParameter("@userId",data.UserId),
                new SqlParameter("@personId",data.PersonId)
            });
            return RedirectToAction("Index", "PhoneBook");
        }

        [HttpPost]
        public ActionResult Update(UserPhoneBookDB data)
        {
            SQLDALManager manager = new SQLDALManager("dbConnString");
            manager.ExecuteStoredProcedure("updateUserPhonebook", new List<SqlParameter>
            {
                new SqlParameter("@userId",data.UserId),
                new SqlParameter("@personId",data.PersonId),
                new SqlParameter("@newPersonId",data.NewPersonId)
            });
            return RedirectToAction("Index", "PhoneBook");
        }

        [HttpPost]
        public ActionResult Delete(UserPhoneBookDB data)
        {
            SQLDALManager manager = new SQLDALManager("dbConnString");
            manager.ExecuteStoredProcedure("deleteUserPhonebook", new List<SqlParameter>
            {
                new SqlParameter("@userId",data.UserId),
                new SqlParameter("@personId",data.PersonId)
            });
            return RedirectToAction("Index", "PhoneBook");
        }
    }
}