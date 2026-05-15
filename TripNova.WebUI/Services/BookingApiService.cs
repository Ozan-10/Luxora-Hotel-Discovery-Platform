using Newtonsoft.Json;
using TripNova.WebUI.Dtos;

namespace TripNova.WebUI.Services
{
    public class BookingApiService
    {
        private readonly HttpClient _httpClient;

        public BookingApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SearchLocationDto>> SearchLocationAsync(string city)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={city}"),

                Headers =
                {
                    { "x-rapidapi-key", "eec7b340afmsh16e04f0253f3e04p121918jsn4eac6f07d62f" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };

            using var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SearchLocationDto>();
            }

            var body = await response.Content.ReadAsStringAsync();

            dynamic jsonData = JsonConvert.DeserializeObject(body);

            var data = jsonData.data.ToObject<List<SearchLocationDto>>();

            return data;
        }

        public async Task<dynamic> GetHotelsAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-1456928&search_type=CITY&arrival_date=2026-06-10&departure_date=2026-06-15&adults=2&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=EUR"),

                Headers =
                {
                    { "x-rapidapi-key", "eec7b340afmsh16e04f0253f3e04p121918jsn4eac6f07d62f" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };

            using var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject(body);
        }

        public async Task<dynamic> GetHotelDetailAsync(string hotelId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/getHotelDetails?hotel_id={hotelId}&arrival_date=2026-06-10&departure_date=2026-06-15&adults=2&children_age=0,17&room_qty=1&languagecode=en-us&currency_code=EUR"),

                Headers =
                {
                    { "x-rapidapi-key", "eec7b340afmsh16e04f0253f3e04p121918jsn4eac6f07d62f" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };

            using var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject(body);
        }

        public async Task<List<HotelSearchDto>> GetHotelsByCityAsync(string destId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id={destId}&search_type=CITY&arrival_date=2026-06-10&departure_date=2026-06-15&adults=2&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=USD"),

                Headers =
        {
            { "x-rapidapi-key", "eec7b340afmsh16e04f0253f3e04p121918jsn4eac6f07d62f" },
            { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
        },
            };

            using var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new List<HotelSearchDto>();
            }

            var body = await response.Content.ReadAsStringAsync();

            dynamic jsonData = JsonConvert.DeserializeObject(body);

            var hotels = jsonData.data.hotels.ToObject<List<HotelSearchDto>>();

            return hotels;
        }
    }
}