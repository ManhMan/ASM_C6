using _4.Client.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace _4.Client.Services
{
    public class AllServices : IAllServices

    {
        private readonly IJSRuntime jsRuntime;
        private NavigationManager navigation;

        public AllServices(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<T> Add<T>(string url, T model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var postTask = await client.PostAsJsonAsync<T>("Create", model);
            return model;
        }

        public async Task<List<T>> GetAll<T>(string url)
        {
            List<T> models = new List<T>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            string TResponse = await response.Content.ReadAsStringAsync();
            models = JsonConvert.DeserializeObject<List<T>>(TResponse);
            return models;
        }

        public async Task<T> GetById<T>(string url, Guid id)
        {

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url + id);
            string TResponse = await response.Content.ReadAsStringAsync();
            T model = JsonConvert.DeserializeObject<T>(TResponse);
            return model;
        }

        public async Task<bool> Remove<T>(string urlGetById, string urlRemove, Guid id)
        {
            T model = await GetById<T>(urlGetById, id);
            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await client.GetAsync(urlRemove + id);
            string result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }

        public async Task<T> Update<T>(string url, T model, Guid id)
        {
            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url + id.ToString(), content);
            string result = await response.Content.ReadAsStringAsync();
            return model;
        }
    }
}
