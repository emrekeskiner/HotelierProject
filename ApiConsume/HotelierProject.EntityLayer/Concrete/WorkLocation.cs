namespace HotelierProject.EntityLayer.Concrete
{
    public class WorkLocation
    {
        public int WorkLocationId { get; set; }
        public string WorkLocationName { get; set; }
        public string CityName { get; set; }
        public List<AppUser>? AppUsers { get; set; }
    }
}
