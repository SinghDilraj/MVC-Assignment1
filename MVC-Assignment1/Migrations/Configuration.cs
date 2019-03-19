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

            if(!context.Courses.Any(p => p.Name == course1.Name))
            {
                context.Courses.Add(course1);
            }

            context.SaveChanges();

            Course course2 = new Course();
            course2.Name = "Cyber Defense";
            course2.NumberOfHours = 340;

            if (!context.Courses.Any(p => p.Name == course2.Name))
            {
                context.Courses.Add(course2);
            }

            context.SaveChanges();

            Course course3 = new Course();
            course3.Name = "Network Security Diploma";
            course3.NumberOfHours = 400;

            if (!context.Courses.Any(p => p.Name == course3.Name))
            {
                context.Courses.Add(course3);
            }

            context.SaveChanges();

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
                user1.UserName = "johndoe@test.com";
                user1.Email = "johndoe@test.com";

                if (!user1.Courses.Any(p => p.Name == course1.Name))
                {
                    user1.Courses.Add(course1);
                }

                userManager.Create(user1, "Password-1");
            }
            else
            {
                user1 = context
                    .Users
                    .First(p => p.UserName == "johndoe@test.com");
            }

            context.SaveChanges();

            ApplicationUser user2;

            if (!context.Users.Any(
                p => p.UserName == "janedoe@test.com"))
            {
                user2 = new ApplicationUser();
                user2.FirstName = "Jane";
                user2.LastName = "Doe";
                user2.UserName = "janedoe@test.com";
                user2.Email = "janedoe@test.com";

                if (!user2.Courses.Any(p => p.Name == course1.Name))
                {
                    user2.Courses.Add(course1);
                }

                if (!user2.Courses.Any(p => p.Name == course2.Name))
                {
                    user2.Courses.Add(course2);
                }

                userManager.Create(user2, "Password-1");
            }
            else
            {
                user2 = context
                    .Users
                    .First(p => p.UserName == "janedoe@test.com");
            }

            context.SaveChanges();
        }
    }
}
