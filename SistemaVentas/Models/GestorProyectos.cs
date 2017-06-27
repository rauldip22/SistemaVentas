using SistemaVentas.Models.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVentas.Models
{
    public class GestorProyectos
    {
        RepositorioProyectos repo = new RepositorioProyectos();
        public void Guardar(Proyectos proyecto)
        {
            repo.Guardar(proyecto);
        }

        public List<Proyectos> Listar()
        {
            return repo.Listar();
        }

        public void Eliminar(int id)
        {
            repo.Eliminar(id);
        }
        public void Modificar(Proyectos proyecto)
        {
            repo.Modificar(proyecto);
        }

        public Proyectos ObtenerPoryectoPorId(int id)
        {
            return repo.ObtenerProyectoPorId(id);
        }

        public SelectList ObtenerListaDeVendedores()
        {
            return repo.ObtenerListaDeVendedores();
        }
    }
}