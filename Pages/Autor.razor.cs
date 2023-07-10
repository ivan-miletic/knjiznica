using Knjiznica.Services;
using Knjiznica.Vm;
using Microsoft.AspNetCore.Components;

namespace Knjiznica.Pages
{
    public partial class Autor
    {
        [Inject]
        private AutorService autorService { get; set; }

        private List<AutorVm> autori;
        private AutorVm noviAutor = new AutorVm();
        protected override async Task OnInitializedAsync()
        {
            autori = await autorService.GetAutori();
        }

        private async Task DodajAžurirajAutora()
        {
            if (noviAutor.Id == 0)
            {
                await autorService.CreateAutor(noviAutor);
            }
            else
            {
                await autorService.UpdateAutor(noviAutor);
            }

            autori = await autorService.GetAutori();

            noviAutor = new AutorVm();
        }

        private async Task ObrisiAutora(int autorId)
        {
            await autorService.DeleteAutor(autorId);

            autori = await autorService.GetAutori();
        }
    }
}
