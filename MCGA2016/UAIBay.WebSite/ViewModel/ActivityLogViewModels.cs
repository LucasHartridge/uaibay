using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class ActivityLogViewModels
    {

        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public System.DateTime LogDate { get; set; }
        public string Activity { get; set; }
        public string Result { get; set; }
        public string IpAddress { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime ChangedOn { get; set; }
        public Nullable<int> ChangedBy { get; set; }

        public virtual UsuarioViewModels Usuario { get; set; }
    }
}