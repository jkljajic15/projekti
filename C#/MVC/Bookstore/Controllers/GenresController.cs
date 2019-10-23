using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenresController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Genres
        public ActionResult Index()
        {
            var genres = _context.Genres.ToList();
            return View(genres);
        }

        public ActionResult GenreForm()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Id == id);
            if (genre == null)
                return HttpNotFound();

            var model = _context.Genres.Find(id);
            return View("GenreForm", model);
        }
    }
}