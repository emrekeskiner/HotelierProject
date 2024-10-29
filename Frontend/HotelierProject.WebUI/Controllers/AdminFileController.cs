using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelierProject.WebUI.Controllers
{
    public class AdminFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;
            var bytes = stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();

            multipartFormDataContent.Add(byteArrayContent,"file",file.FileName);
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.PostAsync("http://localhost:5115/api/FileProcess", multipartFormDataContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Yükleme Başarılı...";
                return RedirectToAction("Index","AdminFile");
            }

            return View();
        }
    }
}
