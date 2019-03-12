namespace MVC_Assignment1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVC_Assignment1.Models;
    using MVC_Assignment1.Models.Classes;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Assignment1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC_Assignment1.Models.ApplicationDbContext";
        }

        protected override void Seed(MVC_Assignment1.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Courses

            Course course1 = new Course();
            course1.Name = "Software Developer";
            course1.NumberOfHours = 330;

            context.Courses.AddOrUpdate(p => p.Name, course1);

            Course course2 = new Course();
            course2.Name = "Cyber Defense";
            course2.NumberOfHours = 340;

            context.Courses.AddOrUpdate(p => p.Name, course2);

            //UserManager
            var userManager =
               new UserManager<ApplicationUser>(
                       new UserStore<ApplicationUser>(context));

            //Users
            ApplicationUser user1;

            if (!context.Users.Any(
                p => p.UserName == "johndoe@test.com"))
            {
                user1 = new ApplicationUser();
                user1.FirstName = "John";
                user1.LastName = "Doe";
                user1.Courses.Add(course1);
                user1.UserName = "johndoe@test.com";
                user1.Email = "johndoe@test.com";

                userManager.Create(user1, "Password-1");
            }
            else
            {
                user1 = context
                    .Users
                    .First(p => p.UserName == "johndoe@test.com");
            }

            ApplicationUser user2;

            if (!context.Users.Any(
                p => p.UserName == "janedoe@test.com"))
            {
                user2 = new ApplicationUser();
                user1.FirstName = "Jane";
                user1.LastName = "Doe";
                user2.Courses.Add(course1);
                user2.Courses.Add(course2);
                user2.UserName = "janedoe@test.com";
                user2.Email = "janedoe@test.com";

                userManager.Create(user1, "Password-1");
            }
            else
            {
                user2 = context
                    .Users
                    .First(p => p.UserName == "janedoe@test.com");
            }
        }
    }
}
