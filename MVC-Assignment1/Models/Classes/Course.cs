using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Assignment1.Models.Classes
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfHours { get; set; }
        public virtual List<ApplicationUser> Users { get; set; }

        public Course()
        {
            Users = new List<ApplicationUser>();
        }
    }
}