﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SistemaVentas.Models.AccesoDatos
{
    public class RepositorioProyectos
    {
        public RepositorioProyectos()
        {

        }
        SistemaVentasEntities SistemaDB = new SistemaVentasEntities();
        public void Guardar(Proyectos proyecto)
        {
            SistemaDB.Proyectos.Add(proyecto);
            SistemaDB.SaveChanges();
        }

        public List<Proyectos> Listar()
        {
            return SistemaDB.Proyectos.ToList();
        }

        public void Eliminar(int id)
        {
            var proyecto = SistemaDB.Proyectos.First(x => x.IdProyecto == id);
            SistemaDB.Proyectos.Remove(proyecto);
            SistemaDB.SaveChanges();
        }

        public Proyectos ObtenerProyectoPorId(int id)
        {
            var proyecto = SistemaDB.Proyectos.First(x => x.IdProyecto == id);
            return proyecto;
        }

        public SelectList ObtenerListaDeVendedores()
        {
            return new SelectList(SistemaDB.Vendedores, "IdVendedor", "Apellido");
        }

        public SelectList ObtenerListaDeVendedoresConTodos()
        {
            return new SelectList(SistemaDB.Vendedores, "IdVendedor", "Apellido");
        }
        public void Modificar(Proyectos proyecto)
        {
            var proyectoParaModificar = SistemaDB.Proyectos.First(x => x.IdProyecto == proyecto.IdProyecto);

            proyectoParaModificar.Nombre = proyecto.Nombre;
            proyectoParaModificar.Importe = proyecto.Importe;
            proyectoParaModificar.Porcentaje = proyecto.Porcentaje;
            proyectoParaModificar.Descripcion = proyecto.Descripcion;
            proyectoParaModificar.IdVendedor = proyecto.IdVendedor;
            proyectoParaModificar.FechaCierre = proyecto.FechaCierre;
            proyectoParaModificar.LinkNube = proyecto.LinkNube;
            SistemaDB.SaveChanges();
           
            
            
            
        }
    }
}