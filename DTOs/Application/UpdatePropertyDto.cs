namespace HavenSync_api.DTOs.Application
{
    public class UpdatePropertyDto
    {
        public string Name { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string Suburb { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        public string PropertyType { get; set; } = null!;
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int ParkingSpaces { get; set; }

        public decimal? FloorSizeSqm { get; set; }
        public decimal? ErfSizeSqm { get; set; }

        public bool IsFurnished { get; set; }

        public decimal MonthlyRent { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal? LevyAmount { get; set; }
        public decimal? RatesAndTaxes { get; set; }

        public bool UtilitiesIncluded { get; set; }
        public bool PrepaidElectricity { get; set; }
    }

}
