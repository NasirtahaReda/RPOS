﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RedaV1Entities : DbContext
    {
        public RedaV1Entities()
            : base("name=RedaV1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public virtual DbSet<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<SaleInvoiceDetail> SaleInvoiceDetails { get; set; }
        public virtual DbSet<TempItem> TempItems { get; set; }
        public virtual DbSet<TempItemGroup> TempItemGroups { get; set; }
        public virtual DbSet<vw_TempItem> vw_TempItem { get; set; }
        public virtual DbSet<vw_Inventory> vw_Inventory { get; set; }
        public virtual DbSet<vw_SaleReport> vw_SaleReport { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<SaleInvoice> SaleInvoices { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<vw_Expense> vw_Expense { get; set; }
        public virtual DbSet<Stocking> Stockings { get; set; }
        public virtual DbSet<StockingDetail> StockingDetails { get; set; }
        public virtual DbSet<vw_Stocking> vw_Stocking { get; set; }
        public virtual DbSet<vw_Sale2> vw_Sale2 { get; set; }
        public virtual DbSet<vw_StockingDetails> vw_StockingDetails { get; set; }
        public virtual DbSet<vw_SaleInvoiceSummary> vw_SaleInvoiceSummary { get; set; }
        public virtual DbSet<vw_PurchaseDetails> vw_PurchaseDetails { get; set; }
        public virtual DbSet<ItemBarcode> ItemBarcodes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<vw_Payment> vw_Payment { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<vw_TopSale> vw_TopSale { get; set; }
        public virtual DbSet<vw_SalesByMonth> vw_SalesByMonth { get; set; }
        public virtual DbSet<vw_ReorderItem> vw_ReorderItem { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<vw_NetSummary> vw_NetSummary { get; set; }
        public virtual DbSet<MessageType> MessageTypes { get; set; }
        public virtual DbSet<UserMessage> UserMessages { get; set; }
        public virtual DbSet<vw_PushoverMessage> vw_PushoverMessage { get; set; }
        public virtual DbSet<MarqueeMessage> MarqueeMessages { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<ShiftUser> ShiftUsers { get; set; }
        public virtual DbSet<UserPayment> UserPayments { get; set; }
        public virtual DbSet<vw_ShiftUser> vw_ShiftUser { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<vw_Request> vw_Request { get; set; }
        public virtual DbSet<vw_SaleInvoiceDetails> vw_SaleInvoiceDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        [DbFunction("RedaV1Entities", "ItemMovement")]
        public virtual IQueryable<ItemMovement_Result> ItemMovement(Nullable<int> itemID)
        {
            var itemIDParameter = itemID.HasValue ?
                new ObjectParameter("ItemID", itemID) :
                new ObjectParameter("ItemID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ItemMovement_Result>("[RedaV1Entities].[ItemMovement](@ItemID)", itemIDParameter);
        }
    
        [DbFunction("RedaV1Entities", "Summary")]
        public virtual IQueryable<Summary_Result> Summary(Nullable<int> branchID, Nullable<System.DateTime> from, Nullable<System.DateTime> to)
        {
            var branchIDParameter = branchID.HasValue ?
                new ObjectParameter("BranchID", branchID) :
                new ObjectParameter("BranchID", typeof(int));
    
            var fromParameter = from.HasValue ?
                new ObjectParameter("From", from) :
                new ObjectParameter("From", typeof(System.DateTime));
    
            var toParameter = to.HasValue ?
                new ObjectParameter("To", to) :
                new ObjectParameter("To", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Summary_Result>("[RedaV1Entities].[Summary](@BranchID, @From, @To)", branchIDParameter, fromParameter, toParameter);
        }
    }
}
