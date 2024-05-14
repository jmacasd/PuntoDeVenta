using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios.Entidades
{
    internal class Cliente
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public int AsesorId { get; set; }
        public int TipoClienteId { get; set; }
    }
}
