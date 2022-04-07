using MVCProject.Models.customValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Potkategorija
    {
        public int IDPotkategorija { get; set; }

        [Required(ErrorMessage = "Naziv potkategorije je obavezan!")]
        [Display(Name = "Naziv potkategorije")]
        public string Naziv { get; set; }

        [Display(Name = "Naziv kategorije")]
        public Kategorija Kategorija { get; set; }


  
    }
}