using Microsoft.EntityFrameworkCore;
using Project11_LibraryManagementUIAppCORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project11_LibraryManagementUIAppCORE.DAL
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BorrowHistory> BorrowHistories { get; set; }

        public LibraryDbContext(DbContextOptions options): base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connString = @"Data Source=ABHINAVCREED-PC\SQLEXPRESS;Initial Catalog=creed4;Integrated Security=True";
        //    optionsBuilder.UseSqlServer(connString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<BorrowHistory>().ToTable("BorrowHistory");
        }
    }
}
