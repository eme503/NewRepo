using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Comedor_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Principal()
        {
            return View();
        }
        public ActionResult Desayunos()
        {
            return View();
        }
        public ActionResult Almuerzos()
        {
            return View();
        }

        public ActionResult Cena()
        {
            return View();
        }
    }
}