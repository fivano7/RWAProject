using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Proizvod
    {
        public int IDProizvod { get; set; }


        [Required(ErrorMessage ="Naziv proizvoda je obavezan")]
        [Display(Name = "Naziv proizvoda")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Broj proizvoda je obavezan")]
        [Display(Name = "Broj proizvoda")]

        public string BrojProizvoda { get; set; }

        [Required(ErrorMessage = "Boja proizvoda je obavezna")]
        public string Boja { get; set; }

        [Required(ErrorMessage = "Količina proizvoda je obavezna")]
        [Display(Name = "Količina")]
        public short MinimalnaKolicinaNaSkladistu { get; set; }

        [Required(ErrorMessage = "Cijena proizvoda je obavezna")]
        [Display(Name = "Cijena bez PDV-a")]
        public double CijenaBezPDV { get; set; }

        [Display(Name = "Potkategorija")]
        public Potkategorija Potkategorija { get; set; }

    }
}