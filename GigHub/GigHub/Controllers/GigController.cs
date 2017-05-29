using System;
using System.Collections.Generic;
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

        public GigController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Gig
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigViewModel
            {
                Genres = _dbContext.Genres
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigViewModel viewModel)
        {
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.DateTime,
                Venue = viewModel.Venue,
                GenreId = viewModel.Genre
            };

            _dbContext.Gigs.Add(gig);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}