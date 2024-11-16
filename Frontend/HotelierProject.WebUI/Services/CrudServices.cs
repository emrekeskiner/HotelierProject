using Newtonsoft.Json;
using System.Text.Json;

namespace HotelierProject.WebUI.Services
{
    public class CrudServices
    {
        private readonly HttpClientService _httpClientService;

        public CrudServices(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }


        //Create Operasyonu
        public async Task<bool> Create<T>(T entity, string url)
        {
            var response = await _httpClientService.PostAsync(url, entity);
            return response.IsSuccessStatusCode;
        }

        // Get ById Operasyonu
        public async Task<T?> GetById<T>(string url, int id)
        {
            // url ile adresi birleştiriyoruz.
            var response = await _httpClientService.GetAsync<T>($"{url}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            return default;
        }

        // Get List operasyonu
        public async Task<List<T>?> GetList<T>(string url)
        {
            var response = await _httpClientService.GetAsync<T>(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<T>>(jsonData);
            }

            return default;
        }

        // Update Güncelleme operasyonu 
        public async Task<bool> Update<T>(T entity, string url)
        {
            var response = await _httpClientService.PutAsync(url, entity);
            return response.IsSuccessStatusCode;
        }

        // Silme Operasyonu.
        public async Task<bool> Delete(string url, int id)
        {
            var response = await _httpClientService.DeleteAsync($"{url}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
