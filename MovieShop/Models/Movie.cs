using MovieShop.Models.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }

        [Display(Name = "Release Year")]
        [Year(1900)]
        public int ReleaseYear { get; set; }
        public Genre Genre { get; set; }
        public Director Director { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public ICollection<Copy> Copies { get; set; }
    }
}