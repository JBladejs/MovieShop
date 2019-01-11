using MovieShop.Models.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Models
{
    public class Copy
    {
        public int Id { get; set; }

        [Required, StringLength(5, MinimumLength = 5)]
        [SerialCode]
        public string Code { get; set; }

        [Required]
        public Movie Movie { get; set; }
    }
}
