namespace KnjiznicaAPI.Models
{
    public class PosudbaKnjiga
    {
        public int Id { get; set; }
        public int KnjigaId { get; set; }
        public int KorisnikId { get; set; }
        public DateTime DatumPosudbe { get; set; }
        public DateTime DatumVracanja { get; set; }

        public Knjiga Knjiga { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
