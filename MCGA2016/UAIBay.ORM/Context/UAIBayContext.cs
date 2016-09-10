using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAIBay.ORM.Business;

namespace UAIBay.ORM.Context
{
    public class UAIBayContext:DbContext
    {
        public UAIBayContext() : base("name=UAIBayAccess")
        {

        }

        public virtual DbSet<Categoria> Categorias { get; set; }

    }
}
