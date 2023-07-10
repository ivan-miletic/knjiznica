namespace Knjiznica.Vm
{
    public class PosudbaKnjigaVm
    {
        public int Id { get; set; }
        public int KnjigaId { get; set; }
        public int KorisnikId { get; set; }
        public DateTime DatumPosudbe { get; set; }
        public DateTime DatumVracanja { get; set; }
        public KnjigaVm Knjiga { get; set; }
        public KorisnikVm Korisnik { get; set; }
    }
}
