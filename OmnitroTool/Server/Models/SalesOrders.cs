using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class SalesOrders
    {
        public SalesOrders()
        {
            Returns = new HashSet<Returns>();
            SalesOrderLineItems = new HashSet<SalesOrderLineItems>();
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
        public Guid? ShippingAddressId { get; set; }
        public Guid? BillingAddressId { get; set; }
        public int PaymentPaymentOption { get; set; }
        public decimal? PaymentTotalPaymentAmount { get; set; }
        public int? PaymentCurrency { get; set; }
        public bool VasGiftVasGiftWrap { get; set; }
        public string VasGiftVasGiftNotes { get; set; }
        public string OrderId { get; set; }
        public int State { get; set; }
        public int SalesOrderFulfillmentSyncState { get; set; }
        public int SalesOrderFulfillmentSyncRetryCount { get; set; }
        public int LastCompletedState { get; set; }
        public DateTime OrderCreatedAt { get; set; }
        public DateTime? PickedAt { get; set; }
        public DateTime? PackedAt { get; set; }
        public DateTime? CancelledAt { get; set; }
        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public Guid CustomerId { get; set; }
        public string ShippingCompany { get; set; }
        public string ShippingTrackingId { get; set; }
        public string ShippingState { get; set; }
        public int? CargoCarrier { get; set; }
        public string CargoDocumentUrl { get; set; }
        public string CargoCode { get; set; }

        public virtual SalesOrderAddresses BillingAddress { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Integrations Integration { get; set; }
        public virtual SalesOrderAddresses ShippingAddress { get; set; }
        public virtual Tenants Tenant { get; set; }
        public virtual ICollection<Returns> Returns { get; set; }
        public virtual ICollection<SalesOrderLineItems> SalesOrderLineItems { get; set; }
    }
}
