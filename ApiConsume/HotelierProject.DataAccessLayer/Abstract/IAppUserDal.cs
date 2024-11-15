using HotelierProject.EntityLayer.Concrete;

namespace HotelierProject.DataAccessLayer.Abstract
{
    public interface IAppUserDal:IGenericDal<AppUser>
    {
        List<AppUser> UserListWithWorkLocation();

        int AppUserCount();
    }
}
