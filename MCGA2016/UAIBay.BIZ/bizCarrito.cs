using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BIZ
{
    public class bizCarrito
    {

        public bizCarrito()
        {
            this.ItemCarrito = new HashSet<bizItemCarrito>();
        }

        public int IdCarrito { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Nullable<DateTime> LastUpdate { get; set; }

        public virtual ICollection<bizItemCarrito> ItemCarrito { get; set; }
    }
}
