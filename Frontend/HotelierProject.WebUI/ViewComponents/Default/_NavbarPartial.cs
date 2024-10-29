using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.ViewComponents.Default
{
    public class _NavbarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
