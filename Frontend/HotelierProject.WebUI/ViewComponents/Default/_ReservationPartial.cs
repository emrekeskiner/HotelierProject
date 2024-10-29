using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.ViewComponents.Default
{
    public class _ReservationPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
