using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore.Models.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public Book Book { get; set; }
    }
}