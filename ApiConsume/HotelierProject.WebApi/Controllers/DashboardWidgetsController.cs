using HotelierProject.BusinessLayer.Abstract;
using HotelierProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController:ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;
        


        public DashboardWidgetsController(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }

        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        {
            var value = _staffService.TGetStaffCount();
            return Ok(value);
        }

        [HttpGet("LastFourStaff")]
        public IActionResult LastFourStaff()
        {
            var value = _staffService.TGetLastFourStaffList();
            return Ok(value);
        }

        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var value = _bookingService.TGetBookingCount();
            return Ok(value);
        }

        [HttpGet("UserCount")]
        public IActionResult UserCount()
        {
            var value = _appUserService.TAppUserCount();
            return Ok(value);
        }

        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {
            var value = _roomService.TRoomCount();
            return Ok(value);
        }
        [HttpGet("GetLastSixBookings")]
        public IActionResult GetLastSixBookings()
        {
            var values = _bookingService.TGetLastSixBookings();
            return Ok(values);
        }
    }
}
