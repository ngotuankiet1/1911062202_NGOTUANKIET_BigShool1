using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using _1911062202_NGOTUANKIET_BigShool.Models;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using _1911062202_NGOTUANKIET_BigShool.DTOS;

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
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userID = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userID && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendance already exists!");

            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userID
            };

            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userID = User.Identity.GetUserId();

            var attendance = _dbContext.Attendances
                .SingleOrDefault(a => a.AttendeeId == userID && a.CourseId == id);

            if (attendance == null)
                return NotFound();

            _dbContext.Attendances.Remove(attendance);
            _dbContext.SaveChanges();

            return Ok(id);
        }
    }
}
