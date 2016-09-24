using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class ErrorLogViewModels
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public System.DateTime ErrorDate { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string IpAddress { get; set; }
        public string Url { get; set; }
        public string HttpReferer { get; set; }
        public string UserAgent { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime ChangedOn { get; set; }
        public Nullable<int> ChangedBy { get; set; }

        public virtual UsuarioViewModels Usuario { get; set; }
    }
}