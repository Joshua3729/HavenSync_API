using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HavenSync_api.Infrastructure.Identity
{
    public class AuthDbContext : IdentityDbContext<
        ApplicationUser,
        IdentityRole<Guid>,
        Guid>
    {
        public AuthDbContext(
            DbContextOptions<AuthDbContext> options
        ) : base(options) { }
    }
}

