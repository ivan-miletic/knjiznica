using KnjiznicaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnjiznicaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PosudbaController : Controller
    {
        private readonly AppDbContext _context;

        public PosudbaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosudbaKnjiga>>> GetPosuđeneKnjige()
        {
            var posudeneKnjige = await _context.PosudbeKnjiga
                .Include(x => x.Korisnik)
                .Include(k => k.Knjiga)
                .ToListAsync();

            return posudeneKnjige;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePosudba(int id, PosudbaKnjiga posudba)
        {
            if (id != posudba.Id)
            {
                return BadRequest();
            }

            _context.Entry(posudba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosudbaExists(id))
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
        private bool PosudbaExists(int id)
        {
            return _context.PosudbeKnjiga.Any(a => a.Id == id);
        }
    }
}
