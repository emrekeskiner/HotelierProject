using HotelierProject.WebUI.Dtos.AboutDto;
using HotelierProject.WebUI.Dtos.BookingDto;
using HotelierProject.WebUI.Dtos.RoomDto;
using HotelierProject.WebUI.Services;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelierProject.WebUI.Controllers
{
    public class RoomController : Controller
    {
        private readonly CrudServices _crudServices;

        public RoomController(CrudServices crudServices)
        {
            _crudServices = crudServices;
        }

        public async Task<IActionResult> RoomList()
        {
            var rooms = await _crudServices.GetList<ResultRoomDto>("Room");
            if (rooms != null)
            {
                return View(rooms);
            }
            return View(new List<ResultRoomDto>());
            
        }

        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomDto createRoomDto)
        {
            var createRoom = await _crudServices.Create(createRoomDto,"Room");
           
            if (createRoom)
            {
                return RedirectToAction("RoomList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRoom(int id)
        {
            var room = await _crudServices.GetById<UpdateRoomDto>("Room", id);
           if (room != null)
            {
                return View(room);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            var updateRoom = await _crudServices.Update(updateRoomDto, "Room");

            if (updateRoom)
            {
                return RedirectToAction("RoomList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var deleteRoom = await _crudServices.Delete("Room",id);
            
            if (deleteRoom)
            {

                return RedirectToAction("RoomList");
            }
            return View();
        }

    }
}
