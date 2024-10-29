using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.ViewComponents.Booking
{
    public class _BookingCoverPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
