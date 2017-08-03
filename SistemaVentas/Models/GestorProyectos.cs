using SistemaVentas.Models.AccesoDatos;
using System;
using System.Collections.Generic;
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

        public List<ElementoEstadistico> ListarProyectosPorFecha(DateTime fInicio, DateTime fFin)
        {
            var proyectos = repo.Listar();
            var proyectosFiltrados = new List<Proyectos>();
            foreach(Proyectos proyecto in proyectos)
            {
                if(proyecto.FechaCierre > fInicio && proyecto.FechaCierre < fFin)
                {
                    proyectosFiltrados.Add(proyecto);
                }
            }
            return GenerarEstadisticas(proyectosFiltrados);
        }

        public List<ElementoEstadistico> ListarProyectosPorFecha(DateTime fInicio, DateTime fFin, int id)
        {
            var proyectos = repo.Listar();
            var proyectosFiltrados = new List<Proyectos>();
            foreach (Proyectos proyecto in proyectos)
            {
                if (proyecto.IdVendedor == id && proyecto.FechaCierre > fInicio && proyecto.FechaCierre < fFin)
                {
                    proyectosFiltrados.Add(proyecto);
                }
            }
            return GenerarEstadisticas(proyectosFiltrados);
        }
        public List<ElementoEstadistico> GenerarEstadisticas(List<Proyectos> proyectos)
        {
            var list = new List<ElementoEstadistico>();
            var gan = new decimal();
            var cua = new decimal();
            var ses = new decimal();
            var och = new decimal();
            var per = new decimal();
            foreach (Proyectos proyecto in proyectos)
            {
                switch (proyecto.Porcentaje.Trim())
                {
                    case "Ganada":
                        gan = gan + proyecto.Importe;
                        break;
                    case "40%":
                        cua = cua + proyecto.Importe;
                        break;
                    case "60%":
                        ses = ses + proyecto.Importe;
                        break;
                    case "80%":
                        och = och + proyecto.Importe;
                        break;
                    default:
                        per = per + proyecto.Importe;
                        break;
                }
            }
            list.Add(new ElementoEstadistico("Ganada", gan));
            list.Add(new ElementoEstadistico("40%", cua));
            list.Add(new ElementoEstadistico("60%", ses));
            list.Add(new ElementoEstadistico("80%", och));
            list.Add(new ElementoEstadistico("Perdida", per));
            return list;
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