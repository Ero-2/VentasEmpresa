using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.SkiaSharp;
using System.IO;

namespace EmpresaVentas
{
    internal class ReporteVentas
    {
        private List<Venta> ventas;

        public ReporteVentas(List<Venta> ventas)
        {
            this.ventas = ventas;
        }

        public void GenerarReporteTabular()
        {
            Console.WriteLine("ID\tProducto\tMonto\tFecha\t\tVendedor");
            foreach (var venta in ventas)
            {
                Console.WriteLine($"{venta.Id}\t{venta.Producto}\t{venta.Monto}\t{venta.Fecha.ToShortDateString()}\t{venta.Vendedor}");
            }

        }

        public void GenerarGraficoBarras()
        {
            var modelo = new PlotModel { Title = "Ventas por Producto" };
            var serieBarras = new ColumnSeries { Title = "Monto de Ventas", StrokeColor = OxyColors.Black, StrokeThickness = 1 };

            var productos = new Dictionary<string, double>();
            foreach (var venta in ventas)
            {
                if (!productos.ContainsKey(venta.Producto))
                    productos[venta.Producto] = 0;
                productos[venta.Producto] += venta.Monto;
            }

            foreach (var producto in productos)
            {
                serieBarras.Items.Add(new ColumnItem { Value = producto.Value });
            }

            modelo.Series.Add(serieBarras);
            modelo.Axes.Add(new CategoryAxis { Position = AxisPosition.Bottom, ItemsSource = productos.Keys });
            modelo.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = 0 });

            using (var stream = File.Create("grafico.png"))
            {
                var pngExporter = new PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
                pngExporter.Export(modelo, stream);
            }

            Console.WriteLine("Gráfico generado: grafico.png");
        }

        public void GenerarReporteJerarquico()
        {
            var ventasOrdenadas = ventas.OrderByDescending(v => v.Monto).ToList();

            Console.WriteLine("Ventas más importantes (Monto Descendente):");
            foreach (var venta in ventasOrdenadas)
            {
                Console.WriteLine($"{venta.Id} - {venta.Producto} - {venta.Monto:C} - {venta.Fecha.ToShortDateString()} - {venta.Vendedor}");
            }
        }


    }
}
