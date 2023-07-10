using KnjiznicaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnjiznicaAPI.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
        public class AutoriController : ControllerBase
        {
            private readonly AppDbContext _context;

            public AutoriController(AppDbContext context)
            {
                _context = context;
            }

            // GET: api/Autori
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Autor>>> GetAutori()
            {
                var autori = await _context.Autori.ToListAsync();
                return autori;
            }

            // GET: api/Autori/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Autor>> GetAutor(int id)
            {
                var autor = await _context.Autori.FindAsync(id);

                if (autor == null)
                {
                    return NotFound();
                }

                return autor;
            }

            // POST: api/Autori
            [HttpPost]
            public async Task<ActionResult<Autor>> CreateAutor(Autor autor)
            {
                _context.Autori.Add(autor);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAutor), new { id = autor.Id }, autor);
            }

            // PUT: api/Autori/5
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateAutor(int id, Autor autor)
            {
                if (id != autor.Id)
                {
                    return BadRequest();
                }

                _context.Entry(autor).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(id))
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

            // DELETE: api/Autori/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAutor(int id)
            {
                var autor = await _context.Autori.FindAsync(id);
                if (autor == null)
                {
                    return NotFound();
                }

                _context.Autori.Remove(autor);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool AutorExists(int id)
            {
                return _context.Autori.Any(a => a.Id == id);
            }
        }
}
