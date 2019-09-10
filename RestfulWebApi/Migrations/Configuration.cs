namespace RestfulWebApi.Migrations
{
    using RestfulWebApi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestfulWebApi.Models.RestfulWebApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestfulWebApi.Models.RestfulWebApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Contacts.AddOrUpdate(new Contact[] {
              new Contact { Id = 0, FirstName = "Steven", LastName = "Rogers" },
              new Contact { Id = 1, FirstName = "Tony", LastName = "Stark" },
              new Contact { Id = 2, FirstName = "Thor", LastName = "Odinson" }
              }
            );

        }
    }
}
