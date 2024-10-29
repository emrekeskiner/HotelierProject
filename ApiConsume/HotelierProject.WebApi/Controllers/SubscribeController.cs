using HotelierProject.BusinessLayer.Abstract;
using HotelierProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSubscribe(Subscribe subscribe)
        {
            _subscribeService.TInsert(subscribe);
            return Ok("Başarıyla eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSubscribe(int id)
        {
            var values = _subscribeService.TGetById(id);
            _subscribeService.TDelete(values);
            return Ok("Başarıyla silindi.");
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe subscribe)
        {
            _subscribeService.TUpdate(subscribe);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var values = _subscribeService.TGetById(id);
            return Ok();
        }
    }
}
