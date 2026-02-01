using Microsoft.AspNetCore.Identity;

namespace HavenSync_api.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid OwnerId { get; set; }
    }
}
