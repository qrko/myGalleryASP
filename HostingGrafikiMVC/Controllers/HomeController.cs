using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HostingGrafikiMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.IO;


namespace HostingGrafikiMVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {

        HomeModels home = new HomeModels();

        public ActionResult Index()
        {
            ViewData["Message"] = "Witaj w serwisie hostingu grafiki w ASP.NET MVC2!";

            return View();
        }

        public ActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dodaj(string n)
        {
            foreach (string inputTagName in Request.Files)
            {
                var checkBox = Request.Form["Prywatny"];
                bool checkBoxBool = true;

                if (checkBox == "false")
                    checkBoxBool = false;

                HttpPostedFileBase file = Request.Files[inputTagName];

                Plik p = new Plik
                    {
                        NazwaPliku = Path.GetFileName(file.FileName),
                        GUID = Guid.NewGuid(),
                        Prywatny = checkBoxBool
                    };

                
                if (file.ContentLength > 0)
                {

                    bool plik = false;

                    try
                    {
                        Directory.CreateDirectory(HttpContext.Server.MapPath("../Pliki/") + p.GUID);

                        string filePath = Path.Combine(HttpContext.Server.MapPath("../Pliki/" + p.GUID)
                                , Path.GetFileName(file.FileName));
                        file.SaveAs(filePath);
                        plik = true;
                    }

                    catch { }



                    if (home.DodajObrazek(p) && plik)
                    {
                        ViewData["AkcjaDodawania"] = "Grafika dodana pomyślnie";
                        ViewData["ŚcieżkaPobierania"] = @"http://localhost:29432/Home/Pobierz/" + p.GUID;
                        ViewData["ŚcieżkaPobieraniaBezpośrednia"] = @"http://localhost:29432/Pliki/" + p.GUID + "/" + p.NazwaPliku;
                        ViewData["ŚcieżkaUsuwania"] = @"http://localhost:29432/Home/Usuń/" + home.PobierzGUIDUsuwaniaWgIDPliku(home.PobierzIDwgGUID(p.GUID.ToString()));
                    }

                    else ViewData["AkcjaDodawania"] = "Wystąpił błąd w trakcie dodawania grafiki";
                }
            }

            return View();
        }

        public ActionResult Usuń(string id) 
        {
            if (home.Usuń(id)) 
            {
                ViewData["StatusUsuwania"] = "Usunięto pomyślnie";
            }
            else ViewData["StatusUsuwania"] = "Wystąpił błąd w trakcie usuwania";
            return View();
        }

        public ActionResult Pobierz(string id) 
        {
            Pliki p = home.PobierzPlik(id.ToString());
            Response.Redirect(("/Pliki/" + p.GUID + "/" + p.NazwaPliku));

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
