using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class ReceivingOrders
    {
        public ReceivingOrders()
        {
            ReceivingOrderLineItems = new HashSet<ReceivingOrderLineItems>();
            WayBills = new HashSet<WayBills>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid TenantId { get; set; }
        public string ReferenceNumber { get; set; }
        public Guid? IntegrationId { get; set; }
        public int WmsSyncState { get; set; }
        public int WmsSyncRetryCount { get; set; }
        public int State { get; set; }
        public DateTime? ArrivedToWarehouseAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int TransferType { get; set; }
        public DateTime? CancelledAt { get; set; }

        public virtual Integrations Integration { get; set; }
        public virtual Tenants Tenant { get; set; }
        public virtual BaseTransfers BaseTransfers { get; set; }
        public virtual ICollection<ReceivingOrderLineItems> ReceivingOrderLineItems { get; set; }
        public virtual ICollection<WayBills> WayBills { get; set; }
    }
}
