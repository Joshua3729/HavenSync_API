using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/test-auth")]
public class TestAuthController : ControllerBase
{
    [Authorize]
    [HttpGet("any")]
    public IActionResult AnyUser()
        => Ok("Authenticated user");

    [Authorize(Roles = "Admin")]
    [HttpGet("admin")]
    public IActionResult AdminOnly()
        => Ok("Admin access");

    [Authorize(Roles = "Landlord")]
    [HttpGet("landlord")]
    public IActionResult LandlordOnly()
        => Ok("Landlord access");

    [Authorize(Roles = "Tenant")]
    [HttpGet("tenant")]
    public IActionResult TenantOnly()
        => Ok("Tenant access");
}
