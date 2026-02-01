using Microsoft.AspNetCore.Identity;
using HavenSync_api.Infrastructure.Identity;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace HavenSync_api.Infrastructure.Identity
{
    public static class AuthDbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            var roles = new[] { AuthRoles.Admin, AuthRoles.Landlord, AuthRoles.Tenant };


            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole<Guid>(role));
            }

            var adminEmail = "admin@havensync.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    OwnerId = Guid.NewGuid()
                };

                await userManager.CreateAsync(adminUser, "Admin@1234"); // strong password
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
