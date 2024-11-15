using Microsoft.AspNetCore.Mvc;
namespace HotelierProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardScriptPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
