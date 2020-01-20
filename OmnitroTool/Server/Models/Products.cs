using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class Products
    {
        public Products()
        {
            ProductBarcodes = new HashSet<ProductBarcodes>();
            ReceivingOrderLineItems = new HashSet<ReceivingOrderLineItems>();
            ReturnLineItems = new HashSet<ReturnLineItems>();
            SalesOrderLineItems = new HashSet<SalesOrderLineItems>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid TenantId { get; set; }
        public int ReferenceNumber { get; set; }
        public Guid? IntegrationId { get; set; }
        public int WmsSyncState { get; set; }
        public int WmsSyncRetryCount { get; set; }
        public string Sku { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? TaxRatio { get; set; }
        public int Type { get; set; }
        public string Category { get; set; }
        public int State { get; set; }
        public bool Favorite { get; set; }

        public virtual Integrations Integration { get; set; }
        public virtual Tenants Tenant { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<ProductBarcodes> ProductBarcodes { get; set; }
        public virtual ICollection<ReceivingOrderLineItems> ReceivingOrderLineItems { get; set; }
        public virtual ICollection<ReturnLineItems> ReturnLineItems { get; set; }
        public virtual ICollection<SalesOrderLineItems> SalesOrderLineItems { get; set; }
    }
}
