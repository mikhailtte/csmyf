using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testmvc.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "<h1 align = \"center\">INDEX</h1>";
        }

        public string About()
        {
            ViewBag.Message = "Your application description page.";

            return "<h1 align = \"center\">ABOUT</h1>";
        }

        public string Contact()
        {
            ViewBag.Message = "Your contact page.";

            return "<h1 align = \"center\">CONTACT LOL</h1>";
        }
    }
}