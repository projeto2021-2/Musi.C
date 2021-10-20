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
    public class AlbumController : ControllerBase
    {
        private readonly ProjectContext _context;

        public AlbumController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Album
        [HttpGet]
        [Authorize(Roles ="Usuario, Administrador, Artista")]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbuns()
        {
            return await _context.Albuns.ToListAsync();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        [Authorize(Roles ="Usuario, Administrador, Artista")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _context.Albuns.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/Album/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles ="Administrador, Artista")]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if (id != album.Id)
            {
                return BadRequest();
            }

            _context.Entry(album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
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

        // POST: api/Album
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles ="Administrador, Artista")]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            _context.Albuns.Add(album);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbum", new { id = album.Id }, album);
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        [Authorize(Roles ="Administrador, Artista")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await _context.Albuns.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albuns.Remove(album);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumExists(int id)
        {
            return _context.Albuns.Any(e => e.Id == id);
        }
    }
}
