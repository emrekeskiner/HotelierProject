namespace HotelierProject.EntityLayer.Concrete
{
    public class MessageCategory
    {
        public int MessageCategoryId { get; set; }
        public string MessageCategoryName { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
