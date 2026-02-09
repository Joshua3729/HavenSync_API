using HavenSync_api.Infrastructure.Persistence;
using HavenSync_api.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HavenSync_api.API.Controllers
{
    [ApiController]
    [Route("api/landlord")]
    [Authorize(Roles = "Landlord")]
    public class LandlordController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LandlordController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("properties")]
        public async Task<IActionResult> AddProperty(Property property)
        {
            property.LandlordId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return Ok(property);
        }

        [HttpGet("properties")]
        public IActionResult GetProperties()
        {
            var landlordId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var props = _context.Properties.Where(p => p.LandlordId == landlordId).ToList();
            return Ok(props);
        }
    }
}
