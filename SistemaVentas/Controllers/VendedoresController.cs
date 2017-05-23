﻿using SistemaVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVentas.Controllers
{
    public class VendedoresController : Controller
    {
        // GET: Vendedores
        public ActionResult Index()
        {
            return View();
        }

        // GET: Vendedores/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

                               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vendedores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vendedores/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}