//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LUSSIS.RawCode.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemBackup
    {
        public int ItemId { get; set; }
        public string Category { get; set; }
        public string BinNumber { get; set; }
        public string Description { get; set; }
        public Nullable<int> StockBalance { get; set; }
        public Nullable<int> ReorderLvl { get; set; }
        public Nullable<int> ReorderQty { get; set; }
        public string Unit { get; set; }
        public string Supplier1Id { get; set; }
        public decimal Supplier1Price { get; set; }
        public string Supplier2Id { get; set; }
        public decimal Supplier2Price { get; set; }
        public string Supplier3Id { get; set; }
        public decimal Supplier3Price { get; set; }
        public bool IsCataloged { get; set; }
    }
}
