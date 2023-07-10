using Knjiznica.Vm;
using System.Net.Http.Json;


namespace Knjiznica.Services
{
    public class KnjigaService
    {
        private readonly HttpClient _httpClient;

        public KnjigaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<KnjigaVm>> GetKnjige()
        {
            return await _httpClient.GetFromJsonAsync<List<KnjigaVm>>("api/knjige");
        }

        public async Task<KnjigaVm> GetKnjigaById(int id)
        {
            return await _httpClient.GetFromJsonAsync<KnjigaVm>($"api/knjige/{id}");
        }

        public async Task CreateKnjiga(KnjigaVm knjiga)
        {
            await _httpClient.PostAsJsonAsync("api/knjige", knjiga);
        }

        public async Task UpdateKnjiga(KnjigaVm knjiga)
        {
            await _httpClient.PutAsJsonAsync($"api/knjige/{knjiga.Id}", knjiga);
        }

        public async Task DeleteKnjiga(int id)
        {
            await _httpClient.DeleteAsync($"api/knjige/{id}");
        }
    }
}

