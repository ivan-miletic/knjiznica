using Knjiznica.Vm;
using System.Net.Http.Json;

namespace Knjiznica.Services
{
    public class AutorService
    {
        private readonly HttpClient _httpClient;

        public AutorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AutorVm>> GetAutori()
        {
            return await _httpClient.GetFromJsonAsync<List<AutorVm>>("api/autori");
        }

        public async Task<AutorVm> GetAutorById(int id)
        {
            return await _httpClient.GetFromJsonAsync<AutorVm>($"api/autori/{id}");
        }

        public async Task CreateAutor(AutorVm autor)
        {
            await _httpClient.PostAsJsonAsync("api/autori", autor);
        }

        public async Task UpdateAutor(AutorVm autor)
        {
            await _httpClient.PutAsJsonAsync($"api/autori/{autor.Id}", autor);
        }

        public async Task DeleteAutor(int id)
        {
            await _httpClient.DeleteAsync($"api/autori/{id}");
        }
    }
}
