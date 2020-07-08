﻿using Session3_LibraryManagementUIApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Session3_LibraryManagementUIApp.DAL
{
    public class LibraryDBContext: DbContext
    {
        public LibraryDBContext(): base("LibraryDBContext")
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}