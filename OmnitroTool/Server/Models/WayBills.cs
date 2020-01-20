using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class WayBills
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid? ReceivingOrderId { get; set; }
        public string WayBillNo { get; set; }
        public DateTime? WayBillCreatedAt { get; set; }

        public virtual ReceivingOrders ReceivingOrder { get; set; }
    }
}
