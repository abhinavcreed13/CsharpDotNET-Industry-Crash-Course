using MySql.Data.Entity;
using Session8_LibraryManagementUIMysqlEF6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Session8_LibraryManagementUIMysqlEF6.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext() : base("mysqlConnKey")
        {
            
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}