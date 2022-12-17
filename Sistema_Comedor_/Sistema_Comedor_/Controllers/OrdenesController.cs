using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Comedor_.Controllers
{
    public class OrdenesController : Controller
    {
        //Instancia de nuestro contexto de datos
        modeloDataContext contexto = new modeloDataContext();
        // GET: Ordenes
        public ActionResult Ordenes_Realizadas_Desayunos()
        {
            List<Desayunos> desayunos = contexto.Desayunos.ToList();//Me mostrara los datos de la tabla
            return View(desayunos);
        }
        public ActionResult Ordenes_Realizadas_Almuerzo()
        {
            List<Almuerzo> almuerzos = contexto.Almuerzo.ToList();
            return View(almuerzos);
        }
        public ActionResult Ordenes_Realizadas_Cena()
        {
            List<Cena> cena = contexto.Cena.ToList();
            return View(cena);
        }
    }
}