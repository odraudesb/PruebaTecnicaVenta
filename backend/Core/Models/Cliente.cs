using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Identificacion { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
    }
}
