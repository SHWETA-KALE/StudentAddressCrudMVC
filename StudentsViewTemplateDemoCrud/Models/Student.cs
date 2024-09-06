using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace StudentsViewTemplateDemoCrud.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Name must not contain spaces or special characters.")]
        public string Name { get; set; }
        [Required]
        [Range(1, 120, ErrorMessage = "Please enter a valid age.")]
        public int Age { get; set; }

        public Address Address { get; set; }
    }
}