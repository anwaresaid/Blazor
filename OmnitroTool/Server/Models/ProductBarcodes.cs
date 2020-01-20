using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class ProductBarcodes
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid? ProductId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }

        public virtual Products Product { get; set; }
    }
}
