using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GigHub.Models;

namespace GigHub.Controllers
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
            var upcomingGigs = _dbContext.Gigs
                    .Include(x => x.Artist)
                    .Include(x => x.Genre)
                    .Where(g => g.DateTime > DateTime.Now);
            return View(upcomingGigs);
        }
        
    }
}