using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Grad
    {
        [Display(Name = "Grad")]
        public int IDGrad { get; set; }
        [Display(Name = "Naziv grada")]
        public string Naziv { get; set; }
        public int DrzavaID { get; set; }
    }
}