using Knjiznica.Vm;
using System.Net.Http.Json;

namespace Knjiznica.Services
{
    public class PosudbaService
    {
        private readonly HttpClient _httpClient;

        public PosudbaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PosudbaKnjigaVm>> GetPosuđeneKnjige()
        {
            return await _httpClient.GetFromJsonAsync<List<PosudbaKnjigaVm>>("api/posudba");
        }

        public async Task UpdatePosudba(PosudbaKnjigaVm posudba)
        {
            await _httpClient.PutAsJsonAsync($"api/posudba/{posudba.Id}", posudba);
        }
    }
}
