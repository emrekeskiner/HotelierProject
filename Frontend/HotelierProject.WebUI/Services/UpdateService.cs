namespace HotelierProject.WebUI.Services
{
    public class UpdateService
    {
        private readonly HttpClientService _httpClientService;

        public UpdateService(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<bool> Update<T>(T entity, string url)
        {
            var response = await _httpClientService.PutAsync(url, entity);

            return response.IsSuccessStatusCode;
        }
    }
}
