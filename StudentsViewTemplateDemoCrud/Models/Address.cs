using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsViewTemplateDemoCrud.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Country must not contain spaces or special characters.")]
        public string Country { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "State must not contain spaces or special characters.")]
        public string State { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "City must not contain spaces or special characters.")]
        public string City { get; set; }
    }
}