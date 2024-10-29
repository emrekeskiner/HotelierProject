using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIdController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            
            if (string.IsNullOrEmpty(cityName))
            {
                cityName = "Berlin";
            }
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=tr&name={Uri.EscapeDataString(cityName)}"),
                Headers =
    {
        { "x-rapidapi-key", "3c3900831cmsh65a7d35387f9eb4p1e90dbjsnf2dc1d3ab5fd" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ApiBookingLocationSearchViewModel>>(body);
                return View(values.Take(1).ToList());
            }
            return View();
        }
    }
}
