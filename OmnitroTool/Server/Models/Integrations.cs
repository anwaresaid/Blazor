using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class Integrations
    {
        public Integrations()
        {
            Products = new HashSet<Products>();
            ReceivingOrders = new HashSet<ReceivingOrders>();
            Returns = new HashSet<Returns>();
            SalesOrders = new HashSet<SalesOrders>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid TenantId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public DateTime? LastSyncTime { get; set; }
        public DateTime? ProductCatalogLastSyncTime { get; set; }
        public DateTime? SalesOrdersLastSyncTime { get; set; }
        public DateTime? DeactivationTime { get; set; }
        public int State { get; set; }
        public bool IsCoDactive { get; set; }
        public string CashKey { get; set; }
        public string CreditCardKey { get; set; }
        public string Discriminator { get; set; }
        public string FtpAddress { get; set; }
        public string FtpUsername { get; set; }
        public string FtpPassword { get; set; }
        public string FilePrefix { get; set; }
        public string FileFormat { get; set; }
        public string SearchDestination { get; set; }
        public int? FtpPort { get; set; }
        public string FtpIntegrationDetailsSkukey { get; set; }
        public string FtpIntegrationDetailsTitleKey { get; set; }
        public string FtpIntegrationDetailsBarcodeKey { get; set; }
        public string FtpIntegrationDetailsPriceKey { get; set; }
        public string FtpIntegrationDetailsSalePriceKey { get; set; }
        public string FtpIntegrationDetailsTaxRatioKey { get; set; }
        public string FtpIntegrationDetailsSubBarcodesKey { get; set; }
        public string FtpIntegrationDetailsCategoryKey { get; set; }
        public string FtpIntegrationDetailsImageUrlKey { get; set; }
        public string FtpIntegrationDetailsCreatedAtKey { get; set; }
        public string FtpIntegrationDetailsUpdatedAtKey { get; set; }
        public string CustomerCliendId { get; set; }
        public string Apipassword { get; set; }
        public string ShopLink { get; set; }
        public string TicimaxIntegrationShopLink { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string WooCommerceIntegrationShopLink { get; set; }

        public virtual Tenants Tenant { get; set; }
        public virtual ICollection<Products> Products { get; set; }
        public virtual ICollection<ReceivingOrders> ReceivingOrders { get; set; }
        public virtual ICollection<Returns> Returns { get; set; }
        public virtual ICollection<SalesOrders> SalesOrders { get; set; }
    }
}
