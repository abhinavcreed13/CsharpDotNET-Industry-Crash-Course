using Project11_LibraryManagementUIAppCORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project11_LibraryManagementUIAppCORE.DAL
{
    public static class LibraryDataInitilizer
    {
        public static void Seed(LibraryDbContext context)
        {
            if (context.Books.Count() == 0)
            {
                List<Book> books = new List<Book>
            {
                new Book { Title = "Book1", SerialNumber="ABCD1", Author="Author", Publisher="Pub"},
                new Book { Title = "Book2", SerialNumber="ABCD2",Author="Author", Publisher="Pub"},
                new Book { Title = "Book3", SerialNumber="ABCD3",Author="Author", Publisher="Pub"},
                new Book { Title = "Book4", SerialNumber="ABCD4",Author="Author", Publisher="Pub"},
                new Book { Title = "Book5", SerialNumber="ABCD5",Author="Author", Publisher="Pub"}
            };

                foreach (Book book in books)
                {
                    context.Books.Add(book);
                }

                //save in database
                context.SaveChanges();
            }

            if (context.Customers.Count() == 0)
            {
                List<Customer> customers = new List<Customer>
            {
                new Customer { Name = "Customer1", Address="Add1", Contact="000"},
                new Customer { Name = "Customer2", Address="Add2", Contact="000"},
                new Customer { Name = "Customer3", Address="Add3", Contact="000"},
                new Customer { Name = "Customer4", Address="Add4", Contact="000"},
                new Customer { Name = "Customer5", Address="Add5", Contact="000"}
            };

                customers.ForEach(cus => context.Customers.Add(cus));

                //save in database
                context.SaveChanges();
            }
        }
    }
}
