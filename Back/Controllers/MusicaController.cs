using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;
using musiC.Data;
using musiC.Models;

namespace musiC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MusicaController : ControllerBase
    {
        private readonly ProjectContext _context;

        public MusicaController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Musica
        [HttpGet]
        [Authorize(Roles ="Usuario, Administrador, Artista")]
        public async Task<ActionResult<IEnumerable<Musica>>> GetMusicas()
        {
            return await _context.Musicas.ToListAsync();
        }

        // GET: api/Musica/5
        [HttpGet("{id}")]
        [Authorize(Roles ="Usuario, Administrador, Artista")]
        public async Task<ActionResult<Musica>> GetMusica(int id)
        {
            var musica = await _context.Musicas.FindAsync(id);

            if (musica == null)
            {
                return NotFound();
            }

            return musica;
        }

        // PUT: api/Musica/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles ="Administrador, Artista")]
        public async Task<IActionResult> PutMusica(int id, Musica musica)
        {
            if (id != musica.Id)
            {
                return BadRequest();
            }

            _context.Entry(musica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicaExists(id))
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

        // POST: api/Musica
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles ="Administrador, Artista")]
        public async Task<ActionResult<Musica>> PostMusica(Musica musica)
        {
            _context.Musicas.Add(musica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusica", new { id = musica.Id }, musica);
        }

        // DELETE: api/Musica/5
        [HttpDelete("{id}")]
        [Authorize(Roles ="Administrador, Artista")]
        public async Task<IActionResult> DeleteMusica(int id)
        {
            var musica = await _context.Musicas.FindAsync(id);
            if (musica == null)
            {
                return NotFound();
            }

            _context.Musicas.Remove(musica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicaExists(int id)
        {
            return _context.Musicas.Any(e => e.Id == id);
        }
    }
}
