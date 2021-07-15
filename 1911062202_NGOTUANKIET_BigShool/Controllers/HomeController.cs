using _1911062202_NGOTUANKIET_BigShool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using _1911062202_NGOTUANKIET_BigShool.ViewModels;
using Microsoft.AspNet.Identity;

namespace _1911062202_NGOTUANKIET_BigShool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            var upcommingCourses = _dbContext.Courses
            .Include(c => c.Lecturer)
            .Include(c => c.Category)
            .Where(c => c.Datetime > DateTime.Now && c.IsCanceled == false);
            var userId = User.Identity.GetUserId();

            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = upcommingCourses,
                ShowAction = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }
    }
}