using MovieShop.Models.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Models
{
    public class Director
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [CapitalLetter]
        [Required, StringLength(40)]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [CapitalLetter]
        [Required, StringLength(40)]
        public String LastName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
