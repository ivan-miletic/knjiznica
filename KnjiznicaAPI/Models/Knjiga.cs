namespace KnjiznicaAPI.Models
{
    public class Knjiga
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Status { get; set; }
        public int AutorId { get; set; }
        public int ŽanrId { get; set; }

        public Autor Autor { get; set; }
        public Žanr Žanr { get; set; }
    }
}
