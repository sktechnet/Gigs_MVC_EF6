using System.Linq;
using System.Web.Http;
//using GigHub.Controllers.Api_Controller;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class FollowingController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public FollowingController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            var exists = (_dbContext.Followings.SingleOrDefault(x => x.FollowerId == userId 
                                                                     && x.FolloweeId == dto.FolloweeId));

            if (exists != null)
                return BadRequest("Already following!");

            var following = new Following
            {
                FolloweeId = dto.FolloweeId,
                FollowerId = userId
            };

            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}