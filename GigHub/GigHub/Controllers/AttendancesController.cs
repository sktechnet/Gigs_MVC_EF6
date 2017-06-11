using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }



        [HttpPost]
        public IHttpActionResult Attend([FromBody]AttendanceDTO gig)
        {
            var userId = User.Identity.GetUserId();

            var exists = _dbContext.Attendances.Any(x => x.AttendeeId == userId && x.GigId == gig.GigId);
            if (exists)
            {
                return BadRequest("Attendance already exists!");
            }

            var attend = new Attendance()
            {
                GigId = gig.GigId,
                AttendeeId = userId,
                IsAttending = true 
            };
            _dbContext.Attendances.Add(attend);


            _dbContext.SaveChanges();

            return Ok();
        }

    }
}
