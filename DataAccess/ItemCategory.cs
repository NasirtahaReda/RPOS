//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            this.Stockings = new HashSet<Stocking>();
            this.Items = new HashSet<Item>();
        }
    
        public int ID { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string code { get; set; }
    
        public virtual ICollection<Stocking> Stockings { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
