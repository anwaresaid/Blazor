using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class Returns
    {
        public Returns()
        {
            ReturnLineItems = new HashSet<ReturnLineItems>();
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
        public int State { get; set; }
        public DateTime? ArrivedToWarehouseAt { get; set; }
        public DateTime? RespondedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public Guid? SalesOrderId { get; set; }
        public DateTime? CancelledAt { get; set; }

        public virtual Integrations Integration { get; set; }
        public virtual SalesOrders SalesOrder { get; set; }
        public virtual Tenants Tenant { get; set; }
        public virtual ICollection<ReturnLineItems> ReturnLineItems { get; set; }
    }
}
