using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TgBotApp.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public string Index(int id)
        {
            return $"id= {id}";
        }
    
        public string Hello(int id)
        {
            return $"id= {id}";
        }
    }
}