using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }

        public IActionResult HeadPartial()
        {
            return PartialView();
        }

        public IActionResult PreloaderPartial()
        {
            return PartialView();
        }

        public IActionResult NavHeaderPartial()
        {
            return PartialView();
        }

        public IActionResult HeaderPartial()
        {
            return PartialView();
        }

        public IActionResult SidebarPartial()
        {
            return PartialView();
        }

        public IActionResult FooterPartial()
        {
            return PartialView();
        }

        public IActionResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
