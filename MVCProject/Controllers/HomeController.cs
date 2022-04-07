using MVCProject.Models;
using MVCProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Login()
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return View();
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(Korisnik k)
        {
            if (ModelState.IsValid)
            {
                if(Repo.ProvjeraUspjesnostiLogiranja(k))
                {
                    Session["Uspjeh"] = "Uspjeh";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.poruka = "Netočna kombinacija emaila i lozinke!";
                    return View();
                }
            }
            else
            {
                ViewBag.poruka = "Netočna kombinacija emaila i lozinke!";
                return View();
            }
        }

        public ActionResult Odjava()
        {
            Session["Uspjeh"] = "";

            return RedirectToAction("Login");

        }

        public ActionResult Index()
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            ViewBag.kupacCount = Repo.GetKupciCount();
            return View(Repo.GetKupci());
        }

        [HttpGet]
        public ActionResult Uredi(int id) 
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            ViewBag.gradovi = Repo.GetGradovi();
            return View(Repo.GetKupac(id));
        }

        [HttpPost]
        public ActionResult Uredi(Kupac k)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            if (ModelState.IsValid)
            {
                Repo.UpdateKupac(k); 
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.gradovi = Repo.GetGradovi();
                return View(k);
            }
        }

        [HttpGet]
        public ActionResult Dodaj()
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            ViewBag.gradovi = Repo.GetGradovi();
            return View();
        }

        [HttpPost]
        public ActionResult Dodaj(Kupac k)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            if (ModelState.IsValid)
            {
                Repo.InsertKupac(k);
                return View("Potvrda", k);
            }
            else
            {
                ViewBag.gradovi = Repo.GetGradovi();
                return View(k);
            }
        }

        public ActionResult Racuni()
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            return View();
        }


        public ActionResult DetaljiRacuna(int id)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            return View(Repo.GetSviPodaciRacuna(id));
        }

        public ActionResult Proizvodi()
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            return View(Repo.GetProizvodi());
        }

        public ActionResult Potkategorije()
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            return View(Repo.GetPotkategorije());
        }

        public ActionResult Kategorije()
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            return View(Repo.GetKategorije());
        }

        [HttpGet]
        public ActionResult UrediKategoriju(int id)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            return View(Repo.GetKategorijaById(id));
        }

        [HttpPost]
        public ActionResult UrediKategoriju(Kategorija k)
        {

            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }
            if (ModelState.IsValid)
            {
                Repo.UpdateKategorija(k);
                return RedirectToAction("Kategorije");
            }
            else
            {
                return View(k);
            }
        }

  

        [HttpGet]
        public ActionResult UrediPotkategoriju(int id)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            ViewBag.kategorije = Repo.GetKategorije();
            return View(Repo.GetPotkategorijaById(id));
        }

        [HttpPost]
        public ActionResult UrediPotkategoriju(Potkategorija pk)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }
            Repo.UpdatePotkategorija(pk);
            return RedirectToAction("Potkategorije");

        }

        [HttpGet]
        public ActionResult UrediProizvod(int id)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            ViewBag.potkategorije = Repo.GetPotkategorije();
            return View(Repo.GetProizvodById(id));
        }

        [HttpPost]
        public ActionResult UrediProizvod(Proizvod p)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            Repo.UpdateProizvod(p);
            return RedirectToAction("Proizvodi");

        }

        [HttpGet]
        public ActionResult DodajKategoriju()
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult DodajKategoriju(Kategorija k)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            if (ModelState.IsValid)
            {
                Repo.CreateKategorija(k);
                return View("KategorijaPotvrda", k);
            }
            else
            {
                return View(k);
            }
        }

        [HttpGet]
        public ActionResult DodajPotkategoriju()
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            ViewBag.kategorije = Repo.GetKategorije();
            return View();
        }

        [HttpPost]
        public ActionResult DodajPotkategoriju(Potkategorija pk)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            Repo.CreatePotkategorija(pk);
                return View("PotkategorijaPotvrda", pk);
 
        }

        [HttpGet]
        public ActionResult DodajProizvod()
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            ViewBag.potkategorije = Repo.GetPotkategorije();
            return View();
        }

        [HttpPost]
        public ActionResult DodajProizvod(Proizvod p)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            Repo.CreateProizvod(p);
            return View("ProizvodPotvrda", p);

        }

 
        public ActionResult DeleteKategorija(int id)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            Repo.DeleteKategorija(id);
            return View("BrisanjeKategorija");
        }

        public ActionResult DeletePotkategorija(int id)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            Repo.DeletePotkategorija(id);
            return View("BrisanjePotkategorija");
        }
        public ActionResult DeleteProizvod(int id)
        {
            if ((string)Session["Uspjeh"] != "Uspjeh")
            {
                return RedirectToAction("Login");
            }

            Repo.DeleteProizvod(id);
            return View("BrisanjeProizvoda");
        }
    }
}