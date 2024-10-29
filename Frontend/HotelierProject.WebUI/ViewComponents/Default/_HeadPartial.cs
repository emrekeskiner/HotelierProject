using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.ViewComponents.Default
{
    public class _HeadPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
