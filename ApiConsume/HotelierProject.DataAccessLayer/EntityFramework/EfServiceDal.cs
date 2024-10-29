using HotelierProject.DataAccessLayer.Abstract;
using HotelierProject.DataAccessLayer.Concrete;
using HotelierProject.DataAccessLayer.Repositories;
using HotelierProject.EntityLayer.Concrete;

namespace HotelierProject.DataAccessLayer.EntityFramework
{
    public class EfServiceDal : GenericRepository<Service>, IServicesDal
    {
        public EfServiceDal(Context context) : base(context)
        {
        }
    }
}
