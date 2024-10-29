using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
       {
        { "x-rapidapi-key", "3c3900831cmsh65a7d35387f9eb4p1e90dbjsnf2dc1d3ab5fd" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
         },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
                return View(result);
            }
            return View();
        }
    }
}
