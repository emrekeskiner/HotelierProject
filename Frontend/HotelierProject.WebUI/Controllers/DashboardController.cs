using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.Controllers
{
    public class DashboardController: Controller
    {
        public IActionResult Index()
        {
            return View();

        }
    }
}
