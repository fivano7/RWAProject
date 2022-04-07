using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class AjaxController : Controller
    {
        public ActionResult GetAutoCompleteKupci(string term)
        {
            var podaci = Repo.ReadKupci()
                .Where(k => k.Ime.ToLower().Contains(term) || k.Prezime.ToLower().Contains(term))
                .Select(k => new
                {
                    label = k.ToString(), 
                    value = k.IDKupac
                });

            return Json(podaci, JsonRequestBehavior.AllowGet);
        }
         
        public ActionResult GetRacuniKupca(int id)
        {
            return Json(Repo.GetRacuniKupca(id), JsonRequestBehavior.AllowGet);
        }
    }
}