using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class BaseTransfers
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Discriminator { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public string CargoCompanyName { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? CarriageTransferShipmentDate { get; set; }
        public string CarriageCompanyName { get; set; }
        public string WaybillNumber { get; set; }
        public DateTime? PickupDate { get; set; }
        public string PickupAddress { get; set; }

        public virtual ReceivingOrders IdNavigation { get; set; }
    }
}
