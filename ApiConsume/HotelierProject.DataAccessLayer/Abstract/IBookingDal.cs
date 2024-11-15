using HotelierProject.EntityLayer.Concrete;

namespace HotelierProject.DataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        void BookingStatusChange(int id, string status);

        int GetBookingCount();

        List<Booking> GetLastSixBookings();
    }
}
