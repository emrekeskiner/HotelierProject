using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        [Route("Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            ViewBag.StatusCode = statusCode;
            ViewBag.OriginalPath = statusCodeResult?.OriginalPath;

            switch (statusCode)
            {
                case 400:
                    ViewBag.ErrorMessage = "Geçersiz istek.";
                    break;
                case 401:
                    ViewBag.ErrorMessage = "Yetkisiz erişim. Lütfen giriş yapın.";
                    break;
                case 403:
                    ViewBag.ErrorMessage = "Bu sayfaya erişim izniniz yok.";
                    break;
                case 404:
                    ViewBag.ErrorMessage = "Sayfa bulunamadı.";
                    break;
                case 405:
                    ViewBag.ErrorMessage = "Bu istek yöntemi geçerli değil.";
                    break;
                case 408:
                    ViewBag.ErrorMessage = "İstek zaman aşımına uğradı.";
                    break;
                case 429:
                    ViewBag.ErrorMessage = "Çok fazla istek gönderildi. Lütfen daha sonra tekrar deneyin.";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Sunucu hatası. Lütfen daha sonra tekrar deneyin.";
                    break;
                case 502:
                    ViewBag.ErrorMessage = "Geçersiz yanıt (Bad Gateway).";
                    break;
                case 503:
                    ViewBag.ErrorMessage = "Hizmet geçici olarak kullanılamıyor.";
                    break;
                case 504:
                    ViewBag.ErrorMessage = "Ağ geçidi zaman aşımına uğradı.";
                    break;
                default:
                    ViewBag.ErrorMessage = "Bilinmeyen bir hata oluştu.";
                    break;
            }

            return View("Error");
        }
    }

}
