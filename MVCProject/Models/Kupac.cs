using MVCProject.Models.customValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Kupac
    {
        public int IDKupac { get; set; }

        [Required (ErrorMessage = "Ime je obvezno!")]
        [ImeValidator]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obvezno!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Adresa elektroničke pošte je obavezna!")]
        [EmailAddress(ErrorMessage = "Elektronička adresa nije ispravna!")]
        public string Email { get; set; }
        public string Telefon { get; set; }
        public Grad Grad { get; set; }
         
        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
        
    }
}