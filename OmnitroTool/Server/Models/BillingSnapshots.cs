using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class BillingSnapshots
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid TenantId { get; set; }
        public int Category { get; set; }
        public int Unit { get; set; }
        public decimal Charges { get; set; }
        public int Currency { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }

        public virtual Tenants Tenant { get; set; }
    }
}
