using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using TgBotApp.Models;

namespace TgBotApp.Controllers
{
    public class HomeController : Controller
    {
		public string Index()
        {
            return "TG BOT LOLBOLTBOT0.2";
        }

        public string About()
        {
            return "LOL THIS IS ABOUT";
        }
    
    }
}