namespace HotelierProject.EntityLayer.Concrete
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public int MessageCategoryId { get; set; }
        public MessageCategory? MessageCategory { get; set; }
    }
}
