using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using musiC.Models;
using musiC.Data;

namespace musiC.Controllers
{
    [Route("api/amigos")]
    [ApiController]
    public class AmigosController : ControllerBase
    {
        private readonly ProjectContext _context;

        public AmigosController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Amigos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amigos>>> Getamigos()
        {
            return await _context.amigos.ToListAsync();
        }

        // GET: api/Amigos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amigos>> GetAmigos(int id)
        {
            var amigos = await _context.amigos.FindAsync(id);

            if (amigos == null)
            {
                return NotFound();
            }

            return amigos;
        }

        // PUT: api/Amigos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmigos(int id, Amigos amigos)
        {
            if (id != amigos.Id)
            {
                return BadRequest();
            }

            _context.Entry(amigos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmigosExists(id))
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

        // POST: api/Amigos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Amigos>> PostAmigos(Amigos amigos)
        {
            _context.amigos.Add(amigos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmigos", new { id = amigos.Id }, amigos);
        }

        // DELETE: api/Amigos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmigos(int id)
        {
            var amigos = await _context.amigos.FindAsync(id);
            if (amigos == null)
            {
                return NotFound();
            }

            _context.amigos.Remove(amigos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AmigosExists(int id)
        {
            return _context.amigos.Any(e => e.Id == id);
        }
    }
}
