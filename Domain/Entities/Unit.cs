using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HavenSync_api.Domain.Entities
{
    public class Unit
    {
        public Guid Id { get; set; }

        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;

        public string UnitNumber { get; set; } = string.Empty;

        public bool IsOccupied { get; set; }
    }
}
