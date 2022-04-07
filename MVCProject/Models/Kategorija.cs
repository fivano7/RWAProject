using MVCProject.Models.customValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Kategorija
    {
        public int IDKategorija { get; set; }

        [Required(ErrorMessage = "Naziv kategorije je obavezan!")]
        public string Naziv { get; set; }
    }
}