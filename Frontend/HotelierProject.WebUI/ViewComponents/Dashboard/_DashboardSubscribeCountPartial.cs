using HotelierProject.WebUI.Dtos.InstagramDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelierProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial:ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Start Instagram

            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/keskineremre"),
                Headers =
    {
        { "x-rapidapi-key", "3c3900831cmsh65a7d35387f9eb4p1e90dbjsnf2dc1d3ab5fd" },
        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultInstagramDto>(body);
                ViewBag.instaFollowers = values?.followers;
                ViewBag.instaFollowing = values?.following;

               
            }


            //end Instagram

            //Linkedin


            var request1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Femrekeskiner%2F&include_skills=false&include_certifications=false&include_publications=false&include_honors=false&include_volunteers=false&include_projects=false&include_patents=false&include_courses=false&include_organizations=false&include_profile_status=false&include_company_public_url=false"),
                Headers =
    {
        { "x-rapidapi-key", "3c3900831cmsh65a7d35387f9eb4p1e90dbjsnf2dc1d3ab5fd" },
        { "x-rapidapi-host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response1 = await client.SendAsync(request1))
            {
                response1.EnsureSuccessStatusCode();
                var body = await response1.Content.ReadAsStringAsync();
                var linkedin = JsonConvert.DeserializeObject<ResultLinkedinDto>(body);
                ViewBag.linkedinFollowers = linkedin?.data.follower_count;
            }
            return View();

        }
    }
}
