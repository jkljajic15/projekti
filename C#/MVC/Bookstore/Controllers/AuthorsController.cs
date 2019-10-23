using System.Linq;
using System.Web.Mvc;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET
        public ActionResult Index()
        {
            var authors = _context.Authors.ToList();

            return View(authors);
        }

        public ActionResult New()
        {
            return View("AuthorForm");
        }

        public ActionResult Edit(int id)
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == id);
            if (author == null)
                return HttpNotFound();
            var model = _context.Authors.Find(id);
            return View("AuthorForm", model);
        }

        [HttpPost]
        public ActionResult Save(Author author)
        {
            if (author.Id == 0)
            {
                _context.Authors.Add(author);
                _context.SaveChanges();
            }
            else
            {
                var authorToUpdate = _context.Authors.Single(a => a.Id == author.Id);

                if (authorToUpdate == null)
                    return HttpNotFound();

                authorToUpdate.FirstName = author.FirstName;
                authorToUpdate.LastName = author.LastName;

                _context.SaveChanges();
            }

            return RedirectToAction("Index","Authors");
        }

        [HttpPost]
        public ActionResult Delete(int ?id)
        {
            var authorToDelete = _context.Authors.Single(a => a.Id == id);

            if (authorToDelete == null)
                return HttpNotFound();

            _context.Authors.Remove(authorToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index", "Authors");
        }
    }
}