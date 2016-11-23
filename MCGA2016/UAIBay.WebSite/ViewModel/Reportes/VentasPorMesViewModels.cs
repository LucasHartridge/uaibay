using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UAIBay.WebSite.ViewModel.Reportes
{
    public class VentasPorMesViewModels
    {
        
        public String Fecha { get; set; }
        public int Cantidad { get; set; }

        public double Total { get; set; }

        public static List<VentasPorMesViewModels> ObtenerUltimos12Meses()
        {
            List<VentasPorMesViewModels> valorRetorno = new List<VentasPorMesViewModels>();
            var restar = 0;
            for (int i = 0; i < 12; i++)
            {
                
                var hoy = DateTime.Now;
                var item = new VentasPorMesViewModels();

                //Actualizo los Meses
                var fechaActualizada = hoy.AddMonths(restar);

                //Verifico el Año
                var año = fechaActualizada.Year;
                var mes = fechaActualizada.Month;
                
                item.Fecha = new DateTime(año,mes,1).ToShortDateString();;
                valorRetorno.Add(item);
                restar = restar - 1;
            }
            return valorRetorno;
        }

        public static List<VentasPorMesViewModels> ObtenerReporteFinal(List<VentasPorMesViewModels> reporte)
        {
            var listaRetorno = new List<VentasPorMesViewModels>();
            

            foreach (var item in reporte)
            {
                var mes = Servicios.Framework.Fechas.ObtenerFechasPorMes(Convert.ToDateTime(item.Fecha).Month);
                var año = Convert.ToDateTime(item.Fecha).Year;
                item.Fecha = mes + año;
                listaRetorno.Add(item);
            }

            return listaRetorno;
        }
    }
}