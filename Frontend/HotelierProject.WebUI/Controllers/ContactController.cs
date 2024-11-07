using HotelierProject.WebUI.Dtos.AboutDto;
using HotelierProject.WebUI.Dtos.BookingDto;
using HotelierProject.WebUI.Dtos.ContactDto;
using HotelierProject.WebUI.Dtos.MessageCategoryDto;
using HotelierProject.WebUI.Dtos.SendMessageDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelierProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5115/api/MessageCategory");
            
           
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);

                List<SelectListItem> messageCategoryList = (from x in values
                                                            select new SelectListItem
                                                            {
                                                                Text = x.MessageCategoryName,
                                                                Value = x.MessageCategoryId.ToString()
                                                            }).ToList();
               // messageCategoryList.Insert(0, new SelectListItem { Text = "Seçiniz", Value = "0" });
                ViewBag.messageCategory = messageCategoryList;
      
            
            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
           
            createContactDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());   
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5115/api/Contact", stringContent);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Contact");
            }
               
            return View();
           
        }

        
    }
}
