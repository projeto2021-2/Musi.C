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
    public class ArtistaController : ControllerBase
    {
        private readonly ProjectContext _context;

        public ArtistaController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Artista
        [HttpGet]
        [Authorize(Roles ="Usuario, Administrador, Artista")]
        public async Task<ActionResult<IEnumerable<Artista>>> GetArtistas()
        {
            return await _context.Artistas.ToListAsync();
        }

        // GET: api/Artista/5
        [HttpGet("{id}")]
        [Authorize(Roles ="Usuario, Administrador, Artista")]
        public async Task<ActionResult<Artista>> GetArtista(int id)
        {
            var artista = await _context.Artistas.FindAsync(id);

            if (artista == null)
            {
                return NotFound();
            }

            return artista;
        }

        // PUT: api/Artista/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles ="Administrador")]
        public async Task<IActionResult> PutArtista(int id, Artista artista)
        {
            if (id != artista.Id)
            {
                return BadRequest();
            }

            _context.Entry(artista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistaExists(id))
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

        // POST: api/Artista
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles ="Administrador")]
        public async Task<ActionResult<Artista>> PostArtista(Artista artista)
        {
            _context.Artistas.Add(artista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtista", new { id = artista.Id }, artista);
        }

        // DELETE: api/Artista/5
        [HttpDelete("{id}")]
        [Authorize(Roles ="Administrador")]
        public async Task<IActionResult> DeleteArtista(int id)
        {
            var artista = await _context.Artistas.FindAsync(id);
            if (artista == null)
            {
                return NotFound();
            }

            _context.Artistas.Remove(artista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistaExists(int id)
        {
            return _context.Artistas.Any(e => e.Id == id);
        }
    }
}
