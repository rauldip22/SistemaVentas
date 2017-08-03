using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    public class ElementoEstadistico
    {
        public string Porcentaje { get; set; }
        public decimal Valor { get; set; }
        public ElementoEstadistico(string por, decimal va)
        {
            this.Porcentaje = por;
            this.Valor = va;
        }

    }
}