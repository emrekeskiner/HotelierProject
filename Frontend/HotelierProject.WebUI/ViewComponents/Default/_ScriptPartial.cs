using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.ViewComponents.Default
{
    public class _ScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
