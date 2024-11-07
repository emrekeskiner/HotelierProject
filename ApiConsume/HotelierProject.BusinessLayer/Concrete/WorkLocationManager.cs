using HotelierProject.BusinessLayer.Abstract;
using HotelierProject.DataAccessLayer.Abstract;
using HotelierProject.EntityLayer.Concrete;

namespace HotelierProject.BusinessLayer.Concrete
{
    public class WorkLocationManager : IWorkLocationService
    {
        private readonly IWorkLocationDal _workLocationDal;

        public WorkLocationManager(IWorkLocationDal workLocationDal)
        {
            _workLocationDal = workLocationDal;
        }

        public void TDelete(WorkLocation entity)
        {
            _workLocationDal.Delete(entity);
        }

        public WorkLocation TGetById(int id)
        {
            return _workLocationDal.GetById(id);
        }

        public List<WorkLocation> TGetList()
        {
            return _workLocationDal.GetList();
        }

        public void TInsert(WorkLocation entity)
        {
           _workLocationDal.Insert(entity);
        }

        public void TUpdate(WorkLocation entity)
        {
            _workLocationDal.Update(entity);
        }
    }
}
