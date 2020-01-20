using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class UsageSnapshots
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid TenantId { get; set; }
        public int Category { get; set; }
        public int Unit { get; set; }
        public decimal Value { get; set; }
        public DateTime Period { get; set; }

        public virtual Tenants Tenant { get; set; }
    }
}
