using AutoMapper;
using HotelierProject.DtoLayer.Dtos.RoomDto;
using HotelierProject.EntityLayer.Concrete;

namespace HotelierProject.WebApi.Mapping
{
    public class AutoMapperConfig :Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreateRoomDto,Room>().ReverseMap();
            CreateMap<UpdateRoomDto,Room>().ReverseMap();
            CreateMap<QueryByIdRoomDto,Room>().ReverseMap();
            CreateMap<ResultRoomDto,Room>().ReverseMap();

        }
    }
}
