using HotelierProject.EntityLayer.Concrete;

namespace HotelierProject.BusinessLayer.Abstract
{
    public interface IAppUserService: IGenericService<AppUser>
    {
        List<AppUser> TUserListWithWorkLocation();

        int TAppUserCount();
    }
}
