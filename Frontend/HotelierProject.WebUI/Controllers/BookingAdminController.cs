using HotelierProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelierProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> BookingList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5115/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ChangeReservationStatus(int id, string status)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"http://localhost:5115/api/Booking/UpdateStatus?id={id}&status={Uri.EscapeDataString(status)}";
            var responseMessage = await client.PutAsync(requestUrl, null);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BookingList","BookingAdmin");
            }
            return RedirectToAction("BookingList", "BookingAdmin"); ;
        }
    }
}
