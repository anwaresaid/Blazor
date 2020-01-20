using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class ReturnLineItemShippings
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid? ReturnLineItemId { get; set; }
        public Guid CustomerId { get; set; }
        public string ShippingTrackingId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ReturnLineItems ReturnLineItem { get; set; }
        public virtual ReturnLineItemShippingAddresses ReturnLineItemShippingAddresses { get; set; }
    }
}
