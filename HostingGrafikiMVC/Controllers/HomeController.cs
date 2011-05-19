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

                    Directory.CreateDirectory(HttpContext.Server.MapPath("../Pliki/") + p.GUID.GetHashCode());

                    string filePath = Path.Combine(HttpContext.Server.MapPath("../Pliki/" + p.GUID.GetHashCode())
                            , Path.GetFileName(file.FileName));
                    file.SaveAs(filePath);

                    HomeModels home = new HomeModels();

                    if (home.DodajObrazek(new Plik
                    {
                        NazwaPliku = Path.GetFileName(file.FileName),
                        GUID = Guid.NewGuid(),
                        Prywatny = checkBoxBool
                    }))
                        ViewData["AkcjaDodawania"] = "Grafika dodana pomyślnie";

                    else ViewData["AkcjaDodawania"] = "Wystąpił błąd w trakcie dodawania grafiki";
                }
            }

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
