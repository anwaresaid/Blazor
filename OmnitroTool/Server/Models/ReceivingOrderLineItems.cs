using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class ReceivingOrderLineItems
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid TenantId { get; set; }
        public Guid ReceivingOrderId { get; set; }
        public string Sku { get; set; }
        public int ExpectedQuantity { get; set; }
        public int? AcceptedQuantity { get; set; }
        public DateTime? ProcessedAt { get; set; }

        public virtual Products Products { get; set; }
        public virtual ReceivingOrders ReceivingOrder { get; set; }
    }
}
