

namespace Knjiznica.Vm
{
    public class KnjigaVm
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Status { get; set; }
        public int AutorId { get; set; }
        public int ŽanrId { get; set; }

        public AutorVm Autor { get; set; }
        public ŽanrVm Žanr { get; set; }
    }
}
