//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UAIBay.ORM.Business
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataLog
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
    
        public virtual Usuario Usuario { get; set; }
    }
}
