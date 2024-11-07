namespace HotelierProject.WebUI.Dtos.AppUserDto
{
    public class ResultAppUserDto
    {

            public string name { get; set; }
            public string surname { get; set; }
            public string city { get; set; }
            public string imageUrl { get; set; }
            public object workDepartment { get; set; }
            public int workLocationId { get; set; }
            public Worklocation workLocation { get; set; }
            public int id { get; set; }
            public string email { get; set; }
            
      }

        public class Worklocation
        {
            public int workLocationId { get; set; }
            public string workLocationName { get; set; }
            public string cityName { get; set; }
            public object[] appUsers { get; set; }
        }

    
}
