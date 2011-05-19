using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using HostingGrafikiMVC.Controllers;

namespace HostingGrafikiMVC.Models
{
    public class HomeModels
    {
        BazaDataContext baza = new BazaDataContext();

        public bool DodajObrazek(Plik plik) 
        {
            try
            {
                Pliki p = new Pliki
                {
                    NazwaPliku = plik.NazwaPliku,
                    Prywatny = Convert.ToInt16(plik.Prywatny),
                    GUID = plik.GUID.ToString()
                };           

                baza.Plikis.InsertOnSubmit(p);
                baza.SubmitChanges();

                return true;
            }
            catch { return false; }
            
        }

        public Pliki PobierzPlik(string GUID)
        {
            return baza.Plikis.Single(a => a.GUID == GUID);
        }
    }
}