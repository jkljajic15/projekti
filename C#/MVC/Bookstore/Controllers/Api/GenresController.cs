using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Bookstore.Models;

namespace Bookstore.Controllers.Api
{
    public class GenresController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public GenresController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        public IHttpActionResult GetGenre(int id)
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genre == null)
                return NotFound();

            return Ok(genre);
        }

        [HttpPost]
        public IHttpActionResult CreateGenre(Genre genre)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Genres.Add(genre);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + genre.Id), genre);
        }

        [HttpPut]
        public IHttpActionResult UpdateGenre(int id, Genre genre)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var genreInDb = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genreInDb == null)
                return NotFound();

            genreInDb.Name = genre.Name;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteGenre(int id)
        {
            var genreInDb = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genreInDb == null)
            {
                return NotFound();
            }

            _context.Genres.Remove(genreInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
