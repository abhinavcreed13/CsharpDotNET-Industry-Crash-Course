using Session3_LibraryManagementUIApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Session3_LibraryManagementUIApp.DAL
{
    public class LibraryDataInitializer : DropCreateDatabaseIfModelChanges<LibraryDBContext>
    {
        protected override void Seed(LibraryDBContext context)
        {
            List<Book> books = new List<Book>
            {
                new Book { Title = "Book1", SerialNumber="ABCD1"},
                new Book { Title = "Book2", SerialNumber="ABCD2"},
                new Book { Title = "Book3", SerialNumber="ABCD3"},
                new Book { Title = "Book4", SerialNumber="ABCD4"},
                new Book { Title = "Book5", SerialNumber="ABCD5"}
            };

            foreach(Book book in books)
            {
                context.Books.Add(book);
            }

            //save in database
            context.SaveChanges();
        }
    }
}