using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios.Entidades
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? CorreoElectronico { get; set; }
        public string FraseAcceso { get; set; }
        public int TipoUsuarioId { get; set; }
    }
 }
