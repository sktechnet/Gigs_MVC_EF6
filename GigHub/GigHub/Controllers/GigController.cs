using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.ViewModels;

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
        public ActionResult Create()
        {
            var viewModel = new GigViewModel
            {
                Genres = _dbContext.Genres
            };

            return View(viewModel);
        }
    }
}