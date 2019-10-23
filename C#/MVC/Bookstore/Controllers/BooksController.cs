using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Bookstore.Models;
using Bookstore.ViewModels;

namespace Bookstore.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var books = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.Genre)
                .ToList();

            return View(books);
        }

        public ActionResult New()
        {
            var publishers = _context.Publishers.ToList();
            var authors = _context.Authors.ToList();
            var genres = _context.Genres.ToList();

            var viewModel = new BookFormViewModel
            {
                Book = new Book(),
                Publishers = publishers,
                Authors = authors,
                Genres = genres
            };

            return View("BookForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel
                {
                    Book = new Book(),
                    Publishers = _context.Publishers.ToList(),
                    Authors = _context.Authors.ToList(),
                    Genres = _context.Genres.ToList()
                };

                return View("BookForm", viewModel);
            }

            if (book.Id == 0)
            {
                _context.Books.Add(book);
            }
            else
            {
                var bookToUpdate = _context.Books.Single(b => b.Id == book.Id);

                if (bookToUpdate == null)
                    return HttpNotFound();

                bookToUpdate.Name = book.Name;
                bookToUpdate.DatePublished = book.DatePublished;
                bookToUpdate.AuthorId = book.AuthorId;
                bookToUpdate.PublisherId = book.PublisherId;
                bookToUpdate.GenreId = book.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index","Books");
        }

        [HttpPost]
        public ActionResult Delete(Book book)
        {
            var bookToDelete = _context.Books.SingleOrDefault(b => b.Id == book.Id);

            if (bookToDelete == null)
                return HttpNotFound();

            _context.Books.Remove(bookToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }

        public ActionResult Edit(int id)
        {
            var publishers = _context.Publishers.ToList();
            var authors = _context.Authors.ToList();
            var genres = _context.Genres.ToList();
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
                return HttpNotFound();
            var viewModel = new BookFormViewModel
            {
                Book = book,
                Publishers = publishers,
                Authors = authors,
                Genres = genres
            };
            return View("BookForm", viewModel);
        }
    }
}