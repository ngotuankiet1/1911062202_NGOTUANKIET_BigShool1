using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using _1911062202_NGOTUANKIET_BigShool.Models;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace _1911062202_NGOTUANKIET_BigShool.Controllers
{
    [System.Web.Http.Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Attend([FromBody] int courseId)
        {
            var attendance = new Attendance
            {
                CourseId = courseId,
                AttendeeId = User.Identity.GetUserId()
            };

            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
