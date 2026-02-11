using HavenSync_api.Domain.Entities;
using HavenSync_api.DTOs.Application;
using HavenSync_api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        [Authorize(Roles = "Landlord")]
        [HttpPut("properties/{id}")]
        public async Task<IActionResult> EditProperty(Guid id, [FromBody] UpdatePropertyDto request)
        {
            var landlordId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (landlordId == null)
                return Unauthorized();

            var property = await _context.Properties
                .FirstOrDefaultAsync(p => p.Id == id && p.LandlordId == Guid.Parse(landlordId));

            if (property == null)
                return NotFound("Property not found");

            property.Name = request.Name;
            property.StreetAddress = request.StreetAddress;
            property.Suburb = request.Suburb;
            property.City = request.City;
            property.Province = request.Province;
            property.PostalCode = request.PostalCode;

            property.PropertyType = request.PropertyType;
            property.Bedrooms = request.Bedrooms;
            property.Bathrooms = request.Bathrooms;
            property.ParkingSpaces = request.ParkingSpaces;

            property.FloorSizeSqm = request.FloorSizeSqm;
            property.ErfSizeSqm = request.ErfSizeSqm;

            property.IsFurnished = request.IsFurnished;

            property.MonthlyRent = request.MonthlyRent;
            property.DepositAmount = request.DepositAmount;
            property.LevyAmount = request.LevyAmount;
            property.RatesAndTaxes = request.RatesAndTaxes;

            property.UtilitiesIncluded = request.UtilitiesIncluded;
            property.PrepaidElectricity = request.PrepaidElectricity;

            await _context.SaveChangesAsync();

            return Ok(property);
        }


    }
}
