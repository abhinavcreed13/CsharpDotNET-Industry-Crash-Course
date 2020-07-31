using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project10_ShoppingDataDumper
{
    public class ShoppingDbContext: DbContext
    {
        public DbSet<MobilePhoneDataModel> MobilePhoneData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = @"Data Source=ABHINAVCREED-PC\SQLEXPRESS;Initial Catalog=creed;Integrated Security=True";
            optionsBuilder.UseSqlServer(connString);
        }
    }
}
