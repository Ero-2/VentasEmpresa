using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVentas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ventas = new List<Venta>
        {
            new Venta { Id = 1, Producto = "Producto A", Monto = 1000, Fecha = DateTime.Now.AddDays(-1), Vendedor = "Vendedor 1" },
            new Venta { Id = 2, Producto = "Producto B", Monto = 1500, Fecha = DateTime.Now.AddDays(-2), Vendedor = "Vendedor 2" },
            new Venta { Id = 3, Producto = "Producto C", Monto = 500, Fecha = DateTime.Now.AddDays(-3), Vendedor = "Vendedor 1" }
        };

            var reporte = new ReporteVentas(ventas);

            // Generar Reporte Tabular
            reporte.GenerarReporteTabular();

            // Generar Reporte Gráfico
            reporte.GenerarGraficoBarras();

            // Generar Reporte Jerárquico
            reporte.GenerarReporteJerarquico();

        }



    }
}
