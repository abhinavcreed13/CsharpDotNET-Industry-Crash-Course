﻿using Session3_LibraryManagementUIApp.Models;
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

            List<Customer> customers = new List<Customer>
            {
                new Customer { Name = "Customer1", Address="Add1", Contact="000"},
                new Customer { Name = "Customer2", Address="Add2", Contact="000"},
                new Customer { Name = "Customer3", Address="Add3", Contact="000"},
                new Customer { Name = "Customer4", Address="Add4", Contact="000"},
                new Customer { Name = "Customer5", Address="Add5", Contact="000"}
            };

            // action delegate = function pointer for non-returning functions
            void addCustomer(Customer cusparam)
            {
                context.Customers.Add(cusparam);
            }
            Action<Customer> customerAction = new Action<Customer>(addCustomer);

            //customers.ForEach(customerAction);

            customers.ForEach(cus => context.Customers.Add(cus));

            //func delegate
            bool findCustomer(Customer cusparam)
            {
                return cusparam.CustomerId == 1;
            }

            Func<Customer, bool> findCustomerFunc = new Func<Customer, bool>(findCustomer);
            bool foundCus = findCustomerFunc(customers[0]);

            //predicate delegate
            Predicate<Customer> customerPredicate = new Predicate<Customer>(findCustomer);

            //Customer cusval = customers.Find(customerPredicate);
            Customer cusval = customers.Find(cus => cus.CustomerId == 1);
            
            //save in database
            context.SaveChanges();
        }
    }
}