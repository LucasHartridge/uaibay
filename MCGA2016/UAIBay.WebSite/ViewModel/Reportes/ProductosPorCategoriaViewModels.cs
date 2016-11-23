using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UAIBay.WebSite.ViewModel;

namespace UAIBay.WebSite.ViewModel.Reportes
{
    public class ProductosPorCategoriaViewModels
    {
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
        public static List<ProductosPorCategoriaViewModels> ObtenerCantidadDeProductosPorCategoria(List<ProductoViewModels> productosVM)
        {
            var reporteProductos = new List<ProductosPorCategoriaViewModels>();

            //Agrupa en una lista
            var groupedCustomerList = productosVM 
                .GroupBy(u => u.IdCategoria)
                .Select(grp => grp.ToList())
                .ToList();

            foreach (var group in groupedCustomerList)
            {
                var producto = new ProductosPorCategoriaViewModels();
                int cantidad = 0;
                producto.Categoria = group.FirstOrDefault().Categoria.Nombre;

                foreach (var item in group)
                {
                    cantidad += 1;
                    producto.Cantidad = cantidad;
                    producto.Total += item.PrecioVenta;
                }

                reporteProductos.Add(producto);
            }

            return reporteProductos;

        }
    }
}