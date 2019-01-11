using MovieShop.Models.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [CapitalLetter]
        [Required, StringLength(20, MinimumLength = 2)]
        public String Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
