using HavenSync_api.Domain.Entities;
using HavenSync_api.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using HavenSync_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Property = HavenSync_api.Domain.Entities.Property;


namespace HavenSync_api.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties => Set<Property>();
        public DbSet<Unit> Units => Set<Unit>();
        public DbSet<Lease> Leases => Set<Lease>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Property>(entity =>
            {
                entity.Property(p => p.MonthlyRent)
                    .HasPrecision(18, 2);

                entity.Property(p => p.DepositAmount)
                    .HasPrecision(18, 2);

                entity.Property(p => p.LevyAmount)
                    .HasPrecision(18, 2);

                entity.Property(p => p.RatesAndTaxes)
                    .HasPrecision(18, 2);

                entity.Property(p => p.FloorSizeSqm)
                    .HasPrecision(10, 2);

                entity.Property(p => p.ErfSizeSqm)
                    .HasPrecision(10, 2);
            });

        }
    }
}