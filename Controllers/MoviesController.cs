using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RolName.CanManegeMovies))
                return View("List");
            
             return View("ReadOnlyList");

        }

        [Authorize(Roles = RolName.CanManegeMovies)]
        public ActionResult New()
        {
            ViewBag.Title = "New Movie";
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                ReleaseDate = DateTime.Now,
                NumberInStock = 0,
                Genres = genres
            };

            return View("MovieForm", viewModel );
        }

        [Authorize(Roles = RolName.CanManegeMovies)]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);
            return View(movie);
        }
        [Authorize(Roles = RolName.CanManegeMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null) return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            ViewBag.Title = "Edit Movie";

            return View("MovieForm", viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.DateAdded = DateTime.Now;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}