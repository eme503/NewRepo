using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Comedor_.Controllers
{
    public class OperacionesController : Controller
    {
        modeloDataContext contexto = new modeloDataContext();
        // GET: Operaciones
        public ActionResult Agregar_Desayuno()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar_Desayuno(Desayunos desayunos)
        {
            contexto.sp_AgregarDesayuno(desayunos.Nombre_Plato, desayunos.Precio);
            contexto.SubmitChanges();
            return RedirectToAction("Ordenes_Realizadas_Desayunos", "Ordenes");

        }
        public ActionResult Actualizar_Desayuno()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Actualizar_Desayuno(Desayunos desayunos)
        {
            contexto.sp_ActualizarDesayuno(Convert.ToInt32(desayunos.Id),desayunos.Nombre_Plato, desayunos.Precio);
            contexto.SubmitChanges();
            return RedirectToAction("Ordenes_Realizadas_Desayunos","Ordenes");
        }
        public ActionResult Eliminar_Desayuno()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Eliminar_Desayuno(int id)
        {
            contexto.sp_EliminarDesayuno(id);
            contexto.SubmitChanges();
            return RedirectToAction("Ordenes_Realizadas_Desayunos","Ordenes");
        }
        public ActionResult Agregar_Almuerzo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar_Almuerzo(Almuerzo almuerzo)
        {
            contexto.sp_AgregarAlumerzo(almuerzo.Nombre_Plato, almuerzo.Precio);
            contexto.SubmitChanges();
            return RedirectToAction("Ordenes_Realizadas_Almuerzo", "Ordenes");
        }
        public ActionResult Actualizar_Almuerzo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Actualizar_Almuerzo(Almuerzo almuerzo)
        {
            contexto.sp_ActualizarAlmuerzo(Convert.ToInt32(almuerzo.Id), almuerzo.Nombre_Plato, almuerzo.Precio);
            contexto.SubmitChanges();
            return RedirectToAction("Ordenes_Realizadas_Almuerzo", "Ordenes");
        }
        public ActionResult Eliminar_Almuerzo(Almuerzo almuerzo)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Eliminar_Almuerzo(int id)
        {
            contexto.sp_EliminarAlmuerzo(id);
            contexto.SubmitChanges();
            return RedirectToAction("Ordenes_Realizadas_Almuerzo", "Ordenes");
        }
        public ActionResult Agregar_Cena()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar_Cena(Cena cena)
        {
            contexto.sp_AgregarCena(cena.Nombre_Plato, cena.Precio);
            contexto.SubmitChanges();
            return RedirectToAction("Ordenes_Realizadas_Cena", "Ordenes");
        }
        public ActionResult Actualizar_Cena()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Actualizar_Cena(Cena cena)
        {
            contexto.sp_ActualizarCena(Convert.ToInt32(cena.Id), cena.Nombre_Plato, cena.Precio);
            contexto.SubmitChanges();
            return RedirectToAction("Ordenes_Realizadas_Cena","Ordenes");
        }
        public ActionResult Eliminar_Cena()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Eliminar_Cena(int id)
        {
            contexto.sp_EliminarCena(id);
            contexto.SubmitChanges();
            return RedirectToAction("Ordenes_Realizadas_Cena","Ordenes");
        }
    }
}