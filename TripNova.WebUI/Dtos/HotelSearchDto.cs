namespace TripNova.WebUI.Dtos
{
    public class HotelSearchDto
    {
        public int hotel_id { get; set; }

        public string accessibilityLabel { get; set; }

        public Property property { get; set; }
    }

    public class Property
    {
        public string name { get; set; }

        public string photoUrls { get; set; }

        public string reviewScoreWord { get; set; }

        public decimal reviewScore { get; set; }

        public PriceBreakdown priceBreakdown { get; set; }

        public string wishlistName { get; set; }
    }

    public class PriceBreakdown
    {
        public GrossPrice grossPrice { get; set; }
    }

    public class GrossPrice
    {
        public string value { get; set; }

        public string currency { get; set; }
    }
}