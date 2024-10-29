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
    public class ServiceManager:IServiceService
    {
        private readonly IServicesDal _servicesDal;

        public ServiceManager(IServicesDal ServiceDal)
        {
            _servicesDal = ServiceDal;
        }

        public void TDelete(Service entity)
        {
            _servicesDal.Delete(entity);
        }

        public Service TGetById(int id)
        {
            return _servicesDal.GetById(id);
        }

        public List<Service> TGetList()
        {
            return _servicesDal.GetList();
        }

        public void TInsert(Service entity)
        {
            _servicesDal.Insert(entity);
        }

        public void TUpdate(Service entity)
        {
            _servicesDal.Update(entity);
        }
    }
}
