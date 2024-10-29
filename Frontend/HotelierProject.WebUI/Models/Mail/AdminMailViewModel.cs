namespace HotelierProject.WebUI.Models.Mail
{
    public class AdminMailViewModel
    {
        public int Name { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
