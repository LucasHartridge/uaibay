using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class DataLogViewModels
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public System.DateTime LodDate { get; set; }
        public string What { get; set; }
        public int WhatId { get; set; }
        public string Name { get; set; }
        public string Columna { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public Nullable<System.DateTime> UndoDate { get; set; }
        public Nullable<int> UndoBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime ChangedOn { get; set; }
        public Nullable<int> ChangedBy { get; set; }

        public virtual UsuarioViewModels Usuario { get; set; }
    }
}