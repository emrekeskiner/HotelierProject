using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace HotelierProject.EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Gender { get; set; }
        public string? ImageUrl { get; set; }
        public string? WorkDepartment { get; set; }
        public int WorkLocationId { get; set; }

       // [JsonIgnore]
        public WorkLocation? WorkLocation { get; set; }
    }
}
