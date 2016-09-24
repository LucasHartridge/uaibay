using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.Repository
{
    class Program
    {

        static void Main()
        {
            var saraza = new CategoriaRepository();

            var lol = saraza.ObtenerTodos();

            foreach (var item in lol)
            {
                Console.WriteLine(item.Nombre);
            }
        }
    }
}
