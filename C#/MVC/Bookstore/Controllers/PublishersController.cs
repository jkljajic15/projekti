using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.Models;


namespace Bookstore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PublishersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublishersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Publishers
        public ViewResult Index()
        {
            var publishers = _context.Publishers.ToList();
            return View(publishers);
        }

        public ActionResult Update(int id)
        {
            var publisher = _context.Publishers.SingleOrDefault(p => p.Id == id);
            if (publisher == null)
                return HttpNotFound();
            return View(publisher);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
            return RedirectToAction("Index","Publishers");
        }

        [HttpPost]
        public ActionResult UpdatePost(Publisher publisher)
        {
            var publisherToUpdate = _context.Publishers.Single(p => p.Id == publisher.Id);

            if (publisher == null)
                return HttpNotFound();

            publisherToUpdate.Name = publisher.Name;
            publisherToUpdate.Location = publisher.Location;
            publisherToUpdate.NumberOfPublications = publisher.NumberOfPublications;

            _context.SaveChanges();

            return RedirectToAction("Index","Publishers");
        }

        [HttpPost]
        public ActionResult Delete(Publisher publisher)
        {
            var publisherToDelete = _context.Publishers.Single(p => p.Id == publisher.Id);

            if (publisherToDelete == null)
                return HttpNotFound();

            _context.Publishers.Remove(publisherToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index", "Publishers");
        }
    }
}