using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardHeadPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
