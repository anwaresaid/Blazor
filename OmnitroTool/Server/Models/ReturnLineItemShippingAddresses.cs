using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class ReturnLineItemShippingAddresses
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int ReferenceNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BaseAddressAddressOne { get; set; }
        public string BaseAddressAddressTwo { get; set; }
        public string BaseAddressDistrict { get; set; }
        public string BaseAddressCity { get; set; }
        public string BaseAddressPostalCode { get; set; }
        public string BaseAddressCountry { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string FullName { get; set; }
        public string FullAddress { get; set; }

        public virtual ReturnLineItemShippings IdNavigation { get; set; }
    }
}
