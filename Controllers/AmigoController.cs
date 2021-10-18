using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using musiC.Data;
using musiC.Models;

namespace musiC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmigoController : ControllerBase
    {
        private readonly ProjectContext _context;

        public AmigoController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Amigo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amigo>>> GetAmigos()
        {
            return await _context.Amigos.ToListAsync();
        }

        // GET: api/Amigo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amigo>> GetAmigo(int id)
        {
            var amigo = await _context.Amigos.FindAsync(id);

            if (amigo == null)
            {
                return NotFound();
            }

            return amigo;
        }

        // PUT: api/Amigo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmigo(int id, Amigo amigo)
        {
            if (id != amigo.Id)
            {
                return BadRequest();
            }

            _context.Entry(amigo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmigoExists(id))
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

        // POST: api/Amigo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Amigo>> PostAmigo(Amigo amigo)
        {
            _context.Amigos.Add(amigo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmigo", new { id = amigo.Id }, amigo);
        }

        // DELETE: api/Amigo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmigo(int id)
        {
            var amigo = await _context.Amigos.FindAsync(id);
            if (amigo == null)
            {
                return NotFound();
            }

            _context.Amigos.Remove(amigo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AmigoExists(int id)
        {
            return _context.Amigos.Any(e => e.Id == id);
        }
    }
}
