namespace Covid19ProjectAPI.Entities
{
    public class WishListResponseDTO
    {
        public string wishListCountryName { get; set; }
        public string userId { get; set; }

        public string countryId { get; set; }
        public double? totalCasesReported { get; set; }

        public double? totalActiveCases { get; set; }

        public double? totalDeaths { get; set; }

        public double? totalCuredCases { get; set; }
    }
}
