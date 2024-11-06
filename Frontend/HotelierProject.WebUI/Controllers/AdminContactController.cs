using HotelierProject.WebUI.Dtos.AboutDto;
using HotelierProject.WebUI.Dtos.ContactDto;
using HotelierProject.WebUI.Dtos.SendMessageDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelierProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ContactMessageList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5115/api/Contact");
            //Contact alanının count değerini almak için 
            var responseMessageContactCount = await client.GetAsync("http://localhost:5115/api/Contact/GetContactCount");
            //gönderilen mesajlar toplamı
            var responseMessageSendMessageCount = await client.GetAsync("http://localhost:5115/api/SendMessage/GetSendMessageCount");

            if (responseMessage.IsSuccessStatusCode && responseMessageContactCount.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);

                var jsonDataContactCount = await responseMessageContactCount.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonDataContactCount;
                var jsonDataSendMessageCount = await responseMessageSendMessageCount.Content.ReadAsStringAsync();
                ViewBag.SendMessageCount = jsonDataSendMessageCount;

                return View(values);
            }

            return View();
        }

        public PartialViewResult SidebarAdminContactPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessageDto)
        {
            createSendMessageDto.SenderMail = "admin@gmail.com";
            createSendMessageDto.SenderName = "Admin";
            createSendMessageDto.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5115/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ContactMessageList", "AdminContact");
            }
            return View();
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5115/api/SendMessage");
            //gönderilen mesajlar toplamı
            var responseMessageSendMessageCount = await client.GetAsync("http://localhost:5115/api/SendMessage/GetSendMessageCount");
            //gelen mesajlar toplamı 
            var responseMessageContactCount = await client.GetAsync("http://localhost:5115/api/Contact/GetContactCount");
            //-------------------
            if (responseMessage.IsSuccessStatusCode && responseMessageSendMessageCount.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);

                var jsonDataSendMessageCount = await responseMessageSendMessageCount.Content.ReadAsStringAsync();
                ViewBag.SendMessageCount = jsonDataSendMessageCount;
                var jsonDataContactCount = await responseMessageContactCount.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonDataContactCount;

                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5115/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);





                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> MessageDetails(int id)
        {
            //id = 1;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5115/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultSendMessageDto>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> GetContactCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5115/api/Contact/GetContactCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
               // var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
               ViewBag.data = jsonData;
                return View();
            }
            return View();
        }

    }
}
