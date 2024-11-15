using HotelierProject.DataAccessLayer.Abstract;
using HotelierProject.DataAccessLayer.Concrete;
using HotelierProject.DataAccessLayer.Repositories;
using HotelierProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelierProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusChange(int id,string status)
        {
            var context = new Context();
           var values = context.Bookings.Find(id);
            values!.Status = status;
            context.SaveChanges();
            
        }

        public int GetBookingCount()
        {
            using var context = new Context();

            return context.Bookings.Count();
        }

        public List<Booking> GetLastSixBookings()
        {
            using var context = new Context();

            return context.Bookings.OrderByDescending(x=> x.BookingId).Take(6).ToList();
        }
    }
}
