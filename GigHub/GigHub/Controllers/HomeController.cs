using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.ViewModels;

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

            var viewModel = new HomeViewModel
            {
                Gigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs"
            };

            return View(viewModel);
        }
    }
}