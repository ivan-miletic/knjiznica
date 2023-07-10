using Knjiznica.Vm;
using System.Net.Http.Json;

namespace Knjiznica.Services
{
    public class KorisnikService
    {
        private readonly HttpClient _httpClient;

        public KorisnikService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<KorisnikVm>> GetKorisnici()
        {
            return await _httpClient.GetFromJsonAsync<List<KorisnikVm>>("api/korisnici");
        }

        public async Task<KorisnikVm> GetKorisnikById(int id)
        {
            return await _httpClient.GetFromJsonAsync<KorisnikVm>($"api/korisnici/{id}");
        }

        public async Task CreateKorisnik(KorisnikVm korisnik)
        {
            await _httpClient.PostAsJsonAsync("api/korisnici", korisnik);
        }

        public async Task UpdateKorisnik(KorisnikVm korisnik)
        {
            await _httpClient.PutAsJsonAsync($"api/autori/{korisnik.Id}", korisnik);
        }

        public async Task DeleteKorisnik(int id)
        {
            await _httpClient.DeleteAsync($"api/korisnici/{id}");
        }
    }
}

