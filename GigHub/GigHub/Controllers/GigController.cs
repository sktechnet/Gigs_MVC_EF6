using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class GigController : Controller
    {
        private ApplicationDbContext _dbContext;
        private DbSet<Genre> _genres;

        public GigController()
        {
            _dbContext = new ApplicationDbContext();
            _genres = _dbContext.Genres;
        }

        // GET: Gig
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigViewModel
            {
                Genres = _genres
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs =
                _dbContext.Attendances
                    .Where(x => x.AttendeeId == userId && x.IsAttending == true)
                    .Select(x => x.Gig)
                    .Include(x=>x.Artist)
                    .Include(x=>x.Genre)
                    .ToList();

            var viewModel = new HomeViewModel
            {
                Gigs = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm Attending"
            };

            return View(viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _genres;
                return View("Create", viewModel);
            }

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                Venue = viewModel.Venue,
                GenreId = viewModel.Genre
            };

            _dbContext.Gigs.Add(gig);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}