using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HostingGrafikiMVC.Models;

namespace HostingGrafikiMVC.Controllers
{
    public class Plik
    {
        public int ID { get; set; }
        public string NazwaPliku { get; set; }
        public Guid GUID { get; set; }
        public bool Prywatny { get; set; }       
       
    }    
}