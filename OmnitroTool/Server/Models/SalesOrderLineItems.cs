using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class SalesOrderLineItems
    {
        public SalesOrderLineItems()
        {
            ReturnLineItems = new HashSet<ReturnLineItems>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid TenantId { get; set; }
        public Guid SalesOrderId { get; set; }
        public int AmountInOrder { get; set; }
        public string Sku { get; set; }
        public decimal? ProductSalePrice { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? ProductTaxRatio { get; set; }

        public virtual Products Products { get; set; }
        public virtual SalesOrders SalesOrder { get; set; }
        public virtual ICollection<ReturnLineItems> ReturnLineItems { get; set; }
    }
}
