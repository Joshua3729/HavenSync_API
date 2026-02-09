using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace HavenSync_api.Domain.Entities
{
    public class Lease
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
        public Guid TenantId { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
