using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
