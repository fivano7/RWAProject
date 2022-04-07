using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class PodaciRacuna
    {
        [Display(Name = "Broj računa")]
        public string BrojRacuna { get; set; }

        [Display(Name = "Naziv proizvoda")]
        public string NazivProizvoda { get; set; }

        [Display(Name = "Količina")]
        public short Kolicina { get; set; }

        [Display(Name = "Naziv potkategorije")]
        public string NazivPotkategorije { get; set; }

        [Display(Name = "Naziv kategorije")]
        public string NazivKategorije { get; set; }

        [Display(Name = "Tip kreditne kartice")]
        public string TipKK { get; set; }

        [Display(Name = "Ime komercijalista")]
        public string Komercijalist { get; set; }

    }
}