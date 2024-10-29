using HotelierProject.BusinessLayer.Abstract;
using HotelierProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _messageService;

        public SendMessageController(ISendMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult SendMessageList()
        {
            var values = _messageService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSendMessage(SendMessage sendMessage)
        {
            _messageService.TInsert(sendMessage);
            return Ok("Mesaj başarıyla gönderildi");
        }

        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            _messageService.TUpdate(sendMessage);
            return Ok("Mesaj başarıyla güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
          var value =  _messageService.TGetById(id);
            _messageService.TDelete(value);
            return Ok("Mesaj başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var values = _messageService.TGetById(id);
            return Ok(values); 
        }
    }
}
