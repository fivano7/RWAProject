using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models.ViewModel
{
    public class UrediVM
    {
        public Kupac Kupac { get; set; }
        public List<Grad> Gradovi { get; set; }
        public int GradID { get; set; }
    }
}