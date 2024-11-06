using HotelierProject.EntityLayer.Concrete;

namespace HotelierProject.BusinessLayer.Abstract
{
    public interface IContactService:IGenericService<Contact>
    {
        public int TGetContactCount();
    }
}
