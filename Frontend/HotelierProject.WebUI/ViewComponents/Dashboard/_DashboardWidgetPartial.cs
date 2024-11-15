using HotelierProject.WebUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelierProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageStaffCount = await client.GetAsync("http://localhost:5115/api/DashboardWidgets/StaffCount");
            var responseMessageBookingCount = await client.GetAsync("http://localhost:5115/api/DashboardWidgets/BookingCount");
            var responseMessageUserCount = await client.GetAsync("http://localhost:5115/api/DashboardWidgets/UserCount");
            var responseMessageRoomCount = await client.GetAsync("http://localhost:5115/api/DashboardWidgets/RoomCount");

            if (responseMessageStaffCount.IsSuccessStatusCode)
            {
                var jsonDataStaffCount = await responseMessageStaffCount.Content.ReadAsStringAsync();
                ViewBag.staffCount = jsonDataStaffCount;

                var jsonDataBookingCount = await responseMessageBookingCount.Content.ReadAsStringAsync();
                ViewBag.bookingCount = jsonDataBookingCount;

                var jsonDataUserCount = await responseMessageUserCount.Content.ReadAsStringAsync();
                ViewBag.userCount = jsonDataUserCount;

                var jsonDataRoomCount = await responseMessageRoomCount.Content.ReadAsStringAsync();
                ViewBag.roomCount = jsonDataRoomCount;
            }
            return View();
        }


    }
}
