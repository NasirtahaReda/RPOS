//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RedaPOS.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.ItemBarcodes = new HashSet<ItemBarcode>();
            this.PurchaseInvoiceDetails = new HashSet<PurchaseInvoiceDetail>();
            this.SaleInvoiceDetails = new HashSet<SaleInvoiceDetail>();
            this.TempItems = new HashSet<TempItem>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public string BarcodeText { get; set; }
        public string Symbology { get; set; }
        public string Model { get; set; }
        public string MadeInCountry { get; set; }
        public Nullable<int> ReorderPoint { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<bool> HasExpireDate { get; set; }
        public Nullable<bool> IsHotItem { get; set; }
        public string OriginalBarcodeText { get; set; }
        public Nullable<bool> OutOfMarket { get; set; }
        public Nullable<int> QuickCode { get; set; }
    
        public virtual ItemCategory ItemCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemBarcode> ItemBarcodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleInvoiceDetail> SaleInvoiceDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TempItem> TempItems { get; set; }
    }
}
