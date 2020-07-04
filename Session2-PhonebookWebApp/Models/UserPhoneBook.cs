using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Session2_PhonebookWebApp.Models
{
    public class UserPhoneBook
    { 
        public UserData User { get; set; }

        public List<UserData> Contacts { get; set; }
    }

    public class UserPhoneBookDB
    {
        public int UserId { get; set; }

        public int PersonId { get; set; }

        public int NewPersonId { get; set; }
    }
}