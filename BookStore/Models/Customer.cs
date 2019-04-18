using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Customer
    {
        [Required]
        [Display(Name ="Your Email")]
        public string CustomerEmail { get; set; }

        [Required]
        [Display(Name = "Your Name")]
        public string CustomerName { get; set; }
    }
}
