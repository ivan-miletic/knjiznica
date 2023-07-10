using Knjiznica.Services;
using Knjiznica.Vm;
using Microsoft.AspNetCore.Components;

namespace Knjiznica.Pages
{
    public partial class Knjiga
    {
        [Inject]
        private KnjigaService knjigaService { get; set; }
        private PosudbaService posudbaService { get; set; }

        private List<KnjigaVm> knjige;
        private KnjigaVm novaKnjiga = new KnjigaVm();
        private List<PosudbaKnjigaVm> posudeneKnjige;
        private List<KnjigaVm> slobodneKnjige;
        private List<KorisnikVm> korisnici;
        private int posudbaKorisnikId;
        private int posudbaKnjigaId;
        protected override async Task OnInitializedAsync()
        {
            knjige = await knjigaService.GetKnjige();
            posudeneKnjige = await posudbaService.GetPosuđeneKnjige();
        }

        private async Task DodajAžurirajKnjigu()
        {
            if (novaKnjiga.Id == 0)
            {
                await knjigaService.CreateKnjiga(novaKnjiga);
            }
            else
            {
                await knjigaService.UpdateKnjiga(novaKnjiga);
            }

            knjige = await knjigaService.GetKnjige();

            novaKnjiga = new KnjigaVm();
        }

        private async Task ObrisiKnjigu(int knjigaId)
        {
            await knjigaService.DeleteKnjiga(knjigaId);

            knjige = await knjigaService.GetKnjige();
        }

        private async Task VratiKnjigu(PosudbaKnjigaVm posudba)
        {
            posudba.DatumVracanja = DateTime.Now;
            await posudbaService.UpdatePosudba(posudba);

            posudeneKnjige = await posudbaService.GetPosuđeneKnjige();
        }
        private async Task PosudiKnjigu()
        {
            var novaPosudba = new PosudbaKnjigaVm
            {
                KorisnikId = posudbaKorisnikId,
                KnjigaId = posudbaKnjigaId,
                DatumPosudbe = DateTime.Now,
                DatumVracanja = DateTime.Now.AddDays(15), // Primjer: Posudba na 15 dana
            };

            await posudbaService.UpdatePosudba(novaPosudba);

            var knjiga = await knjigaService.GetKnjigaById(posudbaKnjigaId);
            knjiga.Status = "Posuđena";
            await knjigaService.UpdateKnjiga(knjiga);

            posudeneKnjige = await posudbaService.GetPosuđeneKnjige();
            slobodneKnjige = await knjigaService.GetKnjige();

            posudbaKorisnikId = 0;
            posudbaKnjigaId = 0;
        }
    }
}
