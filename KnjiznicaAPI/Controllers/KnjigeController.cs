using KnjiznicaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnjiznicaAPI.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class KnjigeController : ControllerBase
        {
            private readonly AppDbContext _context;

            public KnjigeController(AppDbContext context)
            {
                _context = context;
            }

            // GET: api/Knjige
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Knjiga>>> GetKnjige()
            {
                var knjige = await _context.Knjige
                    .Include(x => x.Autor)
                    .Include(k => k.Žanr)
                    .ToListAsync();

                return knjige;
            }

            // GET: api/Knjige/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Knjiga>> GetKnjiga(int id)
            {
                var knjiga = await _context.Knjige
                    .Include(k => k.Autor)
                    .Include(k => k.Žanr)
                    .FirstOrDefaultAsync(k => k.Id == id);

                if (knjiga == null)
                {
                    return NotFound();
                }

                return knjiga;
            }

            // POST: api/Knjige
            [HttpPost]
            public async Task<ActionResult<Knjiga>> CreateKnjiga(Knjiga knjiga)
            {
                _context.Knjige.Add(knjiga);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetKnjiga), new { id = knjiga.Id }, knjiga);
            }

            // PUT: api/Knjige/5
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateKnjiga(int id, Knjiga knjiga)
            {
                if (id != knjiga.Id)
                {
                    return BadRequest();
                }

                _context.Entry(knjiga).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnjigaExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // DELETE: api/Knjige/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteKnjiga(int id)
            {
                var knjiga = await _context.Knjige.FindAsync(id);
                if (knjiga == null)
                {
                    return NotFound();
                }

                _context.Knjige.Remove(knjiga);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool KnjigaExists(int id)
            {
                return _context.Knjige.Any(k => k.Id == id);
            }
        }
}