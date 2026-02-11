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
        public async Task<IActionResult> AddProperty([FromBody] CreatePropertyDto request)
        {
            var landlordId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (landlordId == null) return Unauthorized();

            var property = new Property
            {
                Id = Guid.NewGuid(),
                LandlordId = Guid.Parse(landlordId),

                Name = request.Name,
                StreetAddress = request.StreetAddress,
                Suburb = request.Suburb,
                City = request.City,
                Province = request.Province,
                PostalCode = request.PostalCode,

                PropertyType = request.PropertyType,
                Bedrooms = request.Bedrooms,
                Bathrooms = request.Bathrooms,
                ParkingSpaces = request.ParkingSpaces,
                FloorSizeSqm = request.FloorSizeSqm,
                ErfSizeSqm = request.ErfSizeSqm,
                IsFurnished = request.IsFurnished,

                MonthlyRent = request.MonthlyRent,
                DepositAmount = request.DepositAmount,
                AvailableFrom = request.AvailableFrom,
                UtilitiesIncluded = request.UtilitiesIncluded,
                PrepaidElectricity = request.PrepaidElectricity,

                LevyAmount = request.LevyAmount,
                RatesAndTaxes = request.RatesAndTaxes,
                MunicipalAccountNumber = request.MunicipalAccountNumber,
                TitleDeedNumber = request.TitleDeedNumber,
                IsSectionalTitle = request.IsSectionalTitle,
                HasHOA = request.HasHOA
            };

            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            return Ok(property);
        }
    }
}
