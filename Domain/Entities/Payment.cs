using System;

namespace HavenSync_api.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid LeaseId { get; set; }
        public Lease Lease { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime PaidOn { get; set; }
    }
}



