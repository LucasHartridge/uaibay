using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.Servicios.Framework
{
    public class Fechas
    {
        public static String ObtenerFechasPorMes(int nroMes)
        {
            String mes;

            switch (nroMes)
            {
                case 1:
                    mes = "Ene-";
                    return mes;
                case 2:
                    mes = "Feb-";
                    return mes;
                case 3:
                    mes = "Mar-";
                    return mes;
                case 4:
                    mes = "Abr-";
                    return mes;
                case 5:
                    mes = "May-";
                    return mes;
                case 6:
                    mes = "Jun-";
                    return mes;
                case 7:
                    mes = "Jul-";
                    return mes;
                 case 8:
                    mes = "Ago-";
                    return mes;
                case 9:
                    mes = "Sep-";
                    return mes;
                case 10:
                    mes = "Oct-";
                    return mes;
                case 11:
                    mes = "Nov-";
                    return mes;
                case 12:
                    mes = "Dic-";
                    return mes;         
            }

            return "";
            
        }

       
    }
}
