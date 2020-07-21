using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace Session2_PhonebookWebApp.Models
{
    public class UserModel
    {
        public List<UserData> users { get; set; }

        public List<UserPhoneBook> phonebook { get; set; }

        public UserData UserObject { get; set; }

        public UserPhoneBookDB PhoneBookObject { get; set; }

        public UserModel()
        {
            users = new List<UserData>();
            phonebook = new List<UserPhoneBook>();
            UserObject = new UserData();
            PhoneBookObject = new UserPhoneBookDB();
        }
    }
}