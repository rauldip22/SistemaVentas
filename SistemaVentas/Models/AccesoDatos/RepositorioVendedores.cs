using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models.AccesoDatos
{
    public class RepositorioVendedores
    {
        public RepositorioVendedores()
        {

        }
        SistemaVentasEntities SistemaDB = new SistemaVentasEntities();
        public void Guardar(Vendedores vendedor)
        {
            SistemaDB.Vendedores.Add(vendedor);
            SistemaDB.SaveChanges();
        }

        public List<Vendedores> Listar()
        {
            return SistemaDB.Vendedores.ToList();
        }

        public void Eliminar(int id)
        {
            var vendedor = SistemaDB.Vendedores.First(x => x.IdVendedor == id);
            SistemaDB.Vendedores.Remove(vendedor);
            SistemaDB.SaveChanges();
        }

        public void Modificar(Vendedores vendedor)
        {
            var vendedorParaModificar = SistemaDB.Vendedores.First(x => x.IdVendedor == vendedor.IdVendedor);

            vendedorParaModificar.Apellido = vendedor.Apellido;
            vendedorParaModificar.Nombre = vendedor.Nombre;
            vendedorParaModificar.Email = vendedor.Email;

            SistemaDB.SaveChanges();
        }
    }
}