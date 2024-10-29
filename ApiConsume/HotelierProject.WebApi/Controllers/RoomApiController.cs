using AutoMapper;
using HotelierProject.BusinessLayer.Abstract;
using HotelierProject.DtoLayer.Dtos.RoomDto;
using HotelierProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomApiController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomApiController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateRoom(CreateRoomDto createRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var values = _mapper.Map<Room>(createRoomDto);
            _roomService.TInsert(values);
            return Ok("Kayıt Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var values = _mapper.Map<Room>(updateRoomDto);
            _roomService.TUpdate(values);
            return Ok("Güncelleme Başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var values = _roomService.TGetById(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var values = _roomService.TGetById(id);
            _roomService.TDelete(values);
            return Ok("Kayıt Silindi.");
        }
    }
}
