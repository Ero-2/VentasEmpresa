using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVentas
{
    internal class Venta
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Vendedor { get; set; }

    }
}
