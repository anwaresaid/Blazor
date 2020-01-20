using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class Tenants
    {
        public Tenants()
        {
            BillingSnapshots = new HashSet<BillingSnapshots>();
            Customers = new HashSet<Customers>();
            Integrations = new HashSet<Integrations>();
            Inventory = new HashSet<Inventory>();
            Products = new HashSet<Products>();
            ReceivingOrders = new HashSet<ReceivingOrders>();
            Returns = new HashSet<Returns>();
            SalesOrders = new HashSet<SalesOrders>();
            UsageSnapshots = new HashSet<UsageSnapshots>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string CompanyTitle { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyTaxNo { get; set; }
        public string CompanyTaxAdministration { get; set; }
        public DateTime? TenantLastSyncTimeProductCatalogLastSyncAt { get; set; }
        public DateTime? TenantLastSyncTimeInventoryLastSyncAt { get; set; }
        public DateTime? TenantLastSyncTimeSalesOrdersLastSyncAt { get; set; }
        public DateTime? TenantLastSyncTimeSalesOrdersLastSyncAtFromWms { get; set; }
        public DateTime? TenantLastSyncTimeReceivingOrdersLastSyncAt { get; set; }
        public string Name { get; set; }
        public string WarehouseCode { get; set; }
        public string CustomerCode { get; set; }

        public virtual ICollection<BillingSnapshots> BillingSnapshots { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Integrations> Integrations { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Products> Products { get; set; }
        public virtual ICollection<ReceivingOrders> ReceivingOrders { get; set; }
        public virtual ICollection<Returns> Returns { get; set; }
        public virtual ICollection<SalesOrders> SalesOrders { get; set; }
        public virtual ICollection<UsageSnapshots> UsageSnapshots { get; set; }
    }
}
