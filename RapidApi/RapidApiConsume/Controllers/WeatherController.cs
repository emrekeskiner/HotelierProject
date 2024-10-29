using Microsoft.AspNetCore.Mvc;

namespace RapidApiConsume.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/landon/EN"),
                Headers =
    {
        { "x-rapidapi-key", "3c3900831cmsh65a7d35387f9eb4p1e90dbjsnf2dc1d3ab5fd" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                
            }
            return View();
        }
    }
}
