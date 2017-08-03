using SistemaVentas.Models.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    public class GestorVendedores
    {
        RepositorioVendedores repo = new RepositorioVendedores();
        public void Guardar(Vendedores vendedor)
        {
            repo.Guardar(vendedor);
        }

        public List<Vendedores> Listar()
        {
            return repo.Listar();
        }

        public void Eliminar(int id)
        {
            repo.Eliminar(id);
        }
         public void Modificar(Vendedores vendedor)
        {
            repo.Modificar(vendedor);
        }
        public Vendedores obtenerVendedorPorId(int id)
        {
            return repo.obtenerVendedorPorId(id);
        }
    }
}