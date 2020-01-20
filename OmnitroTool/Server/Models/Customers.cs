using System;
using System.Collections.Generic;

namespace OmnitroTool.Server.Models
{
    public partial class Customers
    {
        public Customers()
        {
            CustomerAddresses = new HashSet<CustomerAddresses>();
            ReturnLineItemShippings = new HashSet<ReturnLineItemShippings>();
            ReturnLineItems = new HashSet<ReturnLineItems>();
            SalesOrders = new HashSet<SalesOrders>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid TenantId { get; set; }
        public int ReferenceNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }

        public virtual Tenants Tenant { get; set; }
        public virtual ICollection<CustomerAddresses> CustomerAddresses { get; set; }
        public virtual ICollection<ReturnLineItemShippings> ReturnLineItemShippings { get; set; }
        public virtual ICollection<ReturnLineItems> ReturnLineItems { get; set; }
        public virtual ICollection<SalesOrders> SalesOrders { get; set; }
    }
}
