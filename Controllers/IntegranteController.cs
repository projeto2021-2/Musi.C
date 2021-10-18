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
    public class IntegranteController : ControllerBase
    {
        private readonly ProjectContext _context;

        public IntegranteController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Integrante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Integrante>>> GetIntegrantes()
        {
            return await _context.Integrantes.ToListAsync();
        }

        // GET: api/Integrante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Integrante>> GetIntegrante(int id)
        {
            var integrante = await _context.Integrantes.FindAsync(id);

            if (integrante == null)
            {
                return NotFound();
            }

            return integrante;
        }

        // PUT: api/Integrante/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntegrante(int id, Integrante integrante)
        {
            if (id != integrante.Id)
            {
                return BadRequest();
            }

            _context.Entry(integrante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntegranteExists(id))
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

        // POST: api/Integrante
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Integrante>> PostIntegrante(Integrante integrante)
        {
            _context.Integrantes.Add(integrante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntegrante", new { id = integrante.Id }, integrante);
        }

        // DELETE: api/Integrante/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntegrante(int id)
        {
            var integrante = await _context.Integrantes.FindAsync(id);
            if (integrante == null)
            {
                return NotFound();
            }

            _context.Integrantes.Remove(integrante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IntegranteExists(int id)
        {
            return _context.Integrantes.Any(e => e.Id == id);
        }
    }
}
