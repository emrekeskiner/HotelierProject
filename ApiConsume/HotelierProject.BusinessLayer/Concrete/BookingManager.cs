using HotelierProject.BusinessLayer.Abstract;
using HotelierProject.DataAccessLayer.Abstract;
using HotelierProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelierProject.BusinessLayer.Concrete
{
   
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TBookingStatusChange(int id, string status)
        {
            _bookingDal.BookingStatusChange(id, status);
        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public Booking TGetById(int id)
        {
           return _bookingDal.GetById(id);
        }

        public List<Booking> TGetList()
        {
           return _bookingDal.GetList();
        }

        public void TInsert(Booking entity)
        {
            _bookingDal.Insert(entity);
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
