using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using _1911062202_NGOTUANKIET_BigShool.Models;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace _1911062202_NGOTUANKIET_BigShool.Controllers
{
    [Authorize]
    public class AttendancesController :ApiController 
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend([FromBody] int courseId)
        {
            var userID = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userID && a.CourseId == courseId))
                return BadRequest("The Attendance already exists!");

            var attendance = new Attendance
            {
                CourseId = courseId,
                AttendeeId = userID
            };

            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
