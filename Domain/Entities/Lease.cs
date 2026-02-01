using HavenSync_api.Domain.Entities;

namespace HavenSync_api.Domain.Entities
{
    public class Lease
    {
        public Guid Id { get; private set; }

        public Guid UnitId { get; private set; }
        public Unit Unit { get; private set; } = null!;

        public Guid TenantId { get; private set; }
    }
}
