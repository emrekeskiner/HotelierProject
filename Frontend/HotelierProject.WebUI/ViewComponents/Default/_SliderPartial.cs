using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.ViewComponents.Default
{
    public class _SliderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return  View();
        }
    }
}
