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
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {
        }

        public List<Staff> GetLastFourStaffList()
        {
           using var context = new Context();

            return context.Staffs.OrderByDescending(s => s.StaffId).Take(4).ToList();
        }

        public int GetStaffCount()
        {
           using var context = new Context();

            return context.Staffs.Count();
        }
    }
}
