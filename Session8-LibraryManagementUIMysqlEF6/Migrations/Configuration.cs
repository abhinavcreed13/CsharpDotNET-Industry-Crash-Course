namespace Session8_LibraryManagementUIMysqlEF6.Migrations
{
    using Session8_LibraryManagementUIMysqlEF6.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Session8_LibraryManagementUIMysqlEF6.DAL.LibraryDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Session8_LibraryManagementUIMysqlEF6.DAL.LibraryDBContext context)
        {
            LibraryDataInitilizer.Seed(context);
        }
    }
}
