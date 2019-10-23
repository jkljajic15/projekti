using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookstore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Published date")]
        public DateTime DatePublished { get; set; }
        public Publisher Publisher { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        
        [Required]
        [Display (Name="Publisher")]
        public int PublisherId { get; set; }
        
        [Required]
        [Display (Name="Genre")]
        public int GenreId { get; set; }
        
        [Required]
        [Display (Name="Author")]
        public int AuthorId { get; set; }
    }
}