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

                Usuwanie u = new Usuwanie()
                {
                    GUID = Guid.NewGuid().ToString(),
                    IDPliku = PobierzIDwgGUID(p.GUID)
                };

                baza.Usuwanies.InsertOnSubmit(u);
                baza.SubmitChanges();

                return true;
            }
            catch { return false; }
            
        }

        /// <summary>
        /// Usuwa dany obrazek z bazy na podstawie jego GUID do usunięcia. Nie usuwa fizycznego pliku z dysku.
        /// </summary>
        /// <param name="GUIDUsuwania"></param>
        /// <returns></returns>
        public bool Usuń(string GUIDUsuwania) 
        {
            try
            {
                //tak wiem, zajebiste zapytanie :D
                baza.Plikis.DeleteOnSubmit(baza.Plikis.Single(a => a.ID == baza.Usuwanies.Single(b => b.GUID == GUIDUsuwania).IDPliku));
                baza.Usuwanies.DeleteOnSubmit(baza.Usuwanies.Single(a => a.GUID == GUIDUsuwania));                
                baza.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public string PobierzGUIDPlikuWgID(int ID)
        {
            return (from id in baza.Plikis
                    where id.ID == ID
                    select id.GUID).ToList()[0];
        }

        public string PobierzGUIDUsuwaniaWgIDPliku(int ID)
        {
            return (from id in baza.Usuwanies
                    where id.IDPliku == ID
                    select id.GUID).ToList()[0];
        }

        public int PobierzIDwgGUID(string GUID) 
        {
            return (from id in baza.Plikis
                    where id.GUID == GUID
                    select id.ID).ToList()[0];
        }

        public Pliki PobierzPlik(string GUID)
        {
            return baza.Plikis.Single(a => a.GUID == GUID);
        }
    }
}