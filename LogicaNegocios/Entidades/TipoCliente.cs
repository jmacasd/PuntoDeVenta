using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios.Entidades
{
    internal class TipoCliente
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public decimal Descuento { get; set; }
    }
}
