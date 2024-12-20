﻿using HotelierProject.BusinessLayer.Abstract;
using HotelierProject.DataAccessLayer.Abstract;
using HotelierProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelierProject.BusinessLayer.Concrete
{
    public class StaffManager:IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal StaffDal)
        {
            _staffDal = StaffDal;
        }

        public void TDelete(Staff entity)
        {
            _staffDal.Delete(entity);
        }

        public Staff TGetById(int id)
        {
            return _staffDal.GetById(id);
        }

        public List<Staff> TGetLastFourStaffList()
        {
           return _staffDal.GetLastFourStaffList();
        }

        public List<Staff> TGetList()
        {
            return _staffDal.GetList();
        }

        public int TGetStaffCount()
        {
            return _staffDal.GetStaffCount();
        }

        public void TInsert(Staff entity)
        {
            _staffDal.Insert(entity);
        }

        public void TUpdate(Staff entity)
        {
            _staffDal.Update(entity);
        }

    
    }
}
