using HotelierProject.WebUI.Dtos.BookingDto;
using HotelierProject.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelierProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly CrudServices _crudServices;

        public BookingAdminController(IHttpClientFactory httpClientFactory, CrudServices crudServices)
        {
            _httpClientFactory = httpClientFactory;
            _crudServices = crudServices;
        }


        public async Task<IActionResult> BookingList()
        {
            //Crud Services içerisindeki GetList Metodunu çağırıyoruz ve bookings değişkenine aktarıyoruz
            var bookings = await _crudServices.GetList<ResultBookingDto>("Booking");

            if (bookings != null)
            {
                // Eğer bookings null değilse sayfaya değerlerle dönüş sağla 
                return View(bookings);
            }

            // Eğer hata varsa boş liste döndür.
            return View(new List<ResultBookingDto>());
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
            return RedirectToAction("BookingList", "BookingAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var booking = await _crudServices.GetById<UpdateBookingDto>("Booking", id);
            if (booking != null)
            {
                return View(booking);
            }
            return View();
        }
       

        [HttpPost]

        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            bool isUpdated = await _crudServices.Update(updateBookingDto, "Booking/UpdateBooking");

            if (isUpdated)
            {
                return RedirectToAction("BookingList", "BookingAdmin");
            }

            return View();
        }
    }
}
