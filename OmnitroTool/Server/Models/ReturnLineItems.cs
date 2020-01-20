using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class ReturnLineItems
    {
        public ReturnLineItems()
        {
            ReturnLineItemImagesReturnLineItem = new HashSet<ReturnLineItemImages>();
            ReturnLineItemImagesReturnLineItemId1Navigation = new HashSet<ReturnLineItemImages>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid TenantId { get; set; }
        public Guid ReturnId { get; set; }
        public Guid? SalesOrderLineItemId { get; set; }
        public string Sku { get; set; }
        public int ReturnReason { get; set; }
        public int? Process { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public int State { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public int AcceptedAmount { get; set; }
        public Guid? CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Products Products { get; set; }
        public virtual Returns Return { get; set; }
        public virtual SalesOrderLineItems SalesOrderLineItem { get; set; }
        public virtual ReturnLineItemShippings ReturnLineItemShippings { get; set; }
        public virtual ICollection<ReturnLineItemImages> ReturnLineItemImagesReturnLineItem { get; set; }
        public virtual ICollection<ReturnLineItemImages> ReturnLineItemImagesReturnLineItemId1Navigation { get; set; }
    }
}
