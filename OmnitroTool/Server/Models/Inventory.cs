using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class Inventory
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid TenantId { get; set; }
        public int? StockAmount { get; set; }
        public string PieceWidthType { get; set; }
        public decimal? PieceWidthValue { get; set; }
        public string PieceLengthType { get; set; }
        public decimal? PieceLengthValue { get; set; }
        public string PieceHeightType { get; set; }
        public decimal? PieceHeightValue { get; set; }
        public string PieceWeightType { get; set; }
        public decimal? PieceWeightValue { get; set; }
        public string Sku { get; set; }
        public DateTime? WmsLastSyncTime { get; set; }

        public virtual Products Products { get; set; }
        public virtual Tenants Tenant { get; set; }
    }
}
