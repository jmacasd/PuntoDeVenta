using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios.Entidades
{
    internal class VentaDetalle
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductosId { get; set; }
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
    }
}
