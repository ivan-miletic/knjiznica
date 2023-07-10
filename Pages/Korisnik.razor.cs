using Knjiznica.Services;
using Knjiznica.Vm;
using Microsoft.AspNetCore.Components;

namespace Knjiznica.Pages
{
    public partial class Korisnik
    {
        [Inject]
        private KorisnikService korisnikService { get; set; }

        private List<KorisnikVm> korisnici;
        private KorisnikVm noviKorisnik = new KorisnikVm();
        protected override async Task OnInitializedAsync()
        {
            korisnici = await korisnikService.GetKorisnici();
        }

        private async Task DodajAžurirajKorisnika()
        {
            if (noviKorisnik.Id == 0)
            {
                await korisnikService.CreateKorisnik(noviKorisnik);
            }
            else
            {
                await korisnikService.UpdateKorisnik(noviKorisnik);
            }

            korisnici = await korisnikService.GetKorisnici();

            noviKorisnik = new KorisnikVm();
        }

        private async Task ObrisiKorisnika(int korisnikId)
        {
            await korisnikService.DeleteKorisnik(korisnikId);

            korisnici = await korisnikService.GetKorisnici();
        }
    }
}
