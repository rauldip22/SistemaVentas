using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public void Modificar(Proyectos proyecto)
        {
            var proyectoParaModificar = SistemaDB.Proyectos.First(x => x.IdProyecto == proyecto.IdProyecto);

            proyectoParaModificar.Nombre = proyecto.Nombre;
            proyectoParaModificar.Importe = proyecto.Importe;
            proyectoParaModificar.Porcentaje = proyecto.Porcentaje;
            proyectoParaModificar.Descripcion = proyecto.Descripcion;
            proyectoParaModificar.IdVendedor = proyecto.IdVendedor;

            SistemaDB.SaveChanges();
        }
    }
}