using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models.AccesoDatos
{
    public class RespositorioVendedores
    {
        SistemaVentasEntities SistemaDB = new SistemaVentasEntities();
        public void Guardar(Vendedores vendedor)
        {
            SistemaDB.Vendedores.Add(vendedor);
            SistemaDB.SaveChanges();
        }
    }
}