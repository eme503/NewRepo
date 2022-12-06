using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Comedor_.Controllers
{
    public class InicioSesionController : Controller
    {
        // GET: InicioSesion
        public ActionResult Registrarse()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            return View();
        }
    }
}