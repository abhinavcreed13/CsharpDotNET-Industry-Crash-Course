namespace Session4_LibraryManagementUIApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Session3_LibraryManagementUIApp.DAL.LibraryDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Session3_LibraryManagementUIApp.DAL.LibraryDBContext";
        }

        protected override void Seed(Session3_LibraryManagementUIApp.DAL.LibraryDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
