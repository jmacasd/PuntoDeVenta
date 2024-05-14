using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios.Entidades
{
    internal class Venta
    {
        public int id {  get; set; }
        public  int Folio { get; set; }
        public  DateTime Fecha { get; set; }
        public int SucursalId { get; set; }
        public  int  ClienteId { get; set; }
        public List<VentaDetalle> Conceptos { get; set; } = new List<VentaDetalle>();
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public int FormaPagoId { get; set; }
    }
}
