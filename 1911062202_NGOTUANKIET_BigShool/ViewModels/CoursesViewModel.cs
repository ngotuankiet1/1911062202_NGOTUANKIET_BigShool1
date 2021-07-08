using _1911062202_NGOTUANKIET_BigShool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1911062202_NGOTUANKIET_BigShool.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}