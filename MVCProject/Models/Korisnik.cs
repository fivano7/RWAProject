using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Korisnik
    {
        [Required (ErrorMessage = "Korisnično ime je obavezno!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezna!")]
        public string Lozinka { get; set; }
    }
}