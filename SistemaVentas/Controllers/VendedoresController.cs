using SistemaVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVentas.Controllers
{
    public class VendedoresController : Controller
    {
        GestorVendedores gestor = new GestorVendedores();
        // GET: Vendedores
        public ActionResult Index()
        {
            return View();
        }

        // GET: Vendedores/Details/5
        public ActionResult Details(int id)
        {
            SistemaVentasEntities SistemaDB = new SistemaVentasEntities();
            var vendedor = SistemaDB.Vendedores.First(x => x.IdVendedor == id);
            return View(vendedor);
        }

        // GET: Vendedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendedores/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            
            try
            {
                // TODO: Add insert logic here
                Vendedores vendedor = new Vendedores();
                vendedor.Apellido = collection["Apellido"];
                vendedor.Nombre = collection["Nombre"];
                vendedor.Email = collection["Email"];

                gestor.Guardar(vendedor);                            

                return RedirectToAction("Listar");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Listar()
        {
            var vendedores = gestor.Listar();
            return View(vendedores);
        } 

        // GET: Vendedores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vendedores/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Vendedores vendedor = new Vendedores();
                vendedor.IdVendedor = id;
                vendedor.Apellido = collection["Apellido"];
                vendedor.Nombre = collection["Nombre"];
                vendedor.Email = collection["Email"];
                gestor.Modificar(vendedor);

                return RedirectToAction("Listar");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vendedores/Delete/5
        public ActionResult Delete(int id)
        {
            SistemaVentasEntities SistemaDB = new SistemaVentasEntities();
            var vendedor = SistemaDB.Vendedores.First(x => x.IdVendedor == id);
            return View(vendedor);
        }

        // POST: Vendedores/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //try
            //{
            gestor.Eliminar(id);
            return RedirectToAction("Listar");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
