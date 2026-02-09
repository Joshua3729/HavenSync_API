using System;
using System.Collections.Generic;

namespace HavenSync_api.Domain.Entities
{
    public class Property
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public Guid LandlordId { get; set; } 
        public List<Lease> Leases { get; set; } = new();
    }
}
