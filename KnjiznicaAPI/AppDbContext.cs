using KnjiznicaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KnjiznicaAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Knjiga> Knjige { get; set; }
        public DbSet<Autor> Autori { get; set; }
        public DbSet<Žanr> Žanrovi { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<PosudbaKnjiga> PosudbeKnjiga { get; set; }
    }
}
