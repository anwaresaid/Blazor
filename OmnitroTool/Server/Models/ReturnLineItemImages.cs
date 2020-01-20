using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class ReturnLineItemImages
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Url { get; set; }
        public Guid? ReturnLineItemId1 { get; set; }
        public Guid? ReturnLineItemId { get; set; }

        public virtual ReturnLineItems ReturnLineItem { get; set; }
        public virtual ReturnLineItems ReturnLineItemId1Navigation { get; set; }
    }
}
