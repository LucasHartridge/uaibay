using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UAIBay.WebSite.ViewModel
{
    public class CarritoViewModels
    {
        public int IdCarrito { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Nullable<DateTime> LastUpdate { get; set; }

        public virtual ICollection<ItemCarritoViewModels> ItemCarrito { get; set; }
    }
}