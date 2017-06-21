using SistemaVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVentas.Controllers
{
    public class ProyectosController : Controller
    {
        GestorProyectos gestor = new GestorProyectos();
        // GET: Proyectos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Proyectos/Details/5
        public ActionResult Details(int id)
        {
            SistemaVentasEntities SistemaDB = new SistemaVentasEntities();
            var proyecto = SistemaDB.Proyectos.First(x => x.IdProyecto == id);
            return View(proyecto);
        }

        // GET: Proyectos/Create
        public ActionResult Create()
        {
            SistemaVentasEntities SistemaDB = new SistemaVentasEntities();
            ViewBag.VendedorId = new SelectList(SistemaDB.Vendedores, "IdVendedor", "Apellido");

            return View();
        }

        // POST: Proyectos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Proyectos proyecto = new Proyectos();
                proyecto.Nombre = collection["Nombre"];
                proyecto.Porcentaje = Int32.Parse(collection["Porcentaje"]);
                proyecto.Importe = Decimal.Parse(collection["Importe"]);
                proyecto.Descripcion = collection["Descripcion"];
                proyecto.IdVendedor = Int32.Parse(collection["IdVendedor"]);
                gestor.Guardar(proyecto);
                return RedirectToAction("Listar");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Listar()
        {
            var proyectos = gestor.Listar();
            return View(proyectos);
        }

        // GET: Proyectos/Edit/5
        public ActionResult Edit(int id)
        {
            SistemaVentasEntities SistemaDB = new SistemaVentasEntities();
            ViewBag.VendedorId = new SelectList(SistemaDB.Vendedores, "IdVendedor", "Apellido");
            var proyecto = SistemaDB.Proyectos.First(x => x.IdProyecto == id);
            return View(proyecto);
        }

        // POST: Proyectos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Proyectos proyecto = new Proyectos();
                proyecto.IdProyecto = id;
                proyecto.Nombre = collection["Nombre"];
                proyecto.Porcentaje = Int32.Parse(collection["Porcentaje"]);
                proyecto.Importe = Decimal.Parse(collection["Importe"]);
                proyecto.Descripcion = collection["Descripcion"];
                proyecto.IdVendedor = Int32.Parse(collection["IdVendedor"]);
                gestor.Modificar(proyecto);
                return RedirectToAction("Listar");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proyectos/Delete/5
        public ActionResult Delete(int id)
        {
            SistemaVentasEntities SistemaDB = new SistemaVentasEntities();
            var proyecto = SistemaDB.Proyectos.First(x => x.IdProyecto == id);
            return View(proyecto);
        }

        // POST: Proyectos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                gestor.Eliminar(id);
                return RedirectToAction("Listar");
            }
            catch
            {
                return View();
            }
        }

    
    }
}
