using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using musiC.Data;
using musiC.Models;

using musiC.Services;

namespace musiC.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ProjectContext _context;

        public UsuarioController(ProjectContext context)
        {
            _context = context;
        }


      [HttpPost]
      [Route("Login")]
      public ActionResult<dynamic> Login([FromBody] Credencial credencial) 
      {
        //Localiza o usuário no banco de dados.
        var usuario = _context.Usuarios.SingleOrDefault(u => u.Login == credencial.Login);

        if (usuario == null || !SenhaService.CompararHash(credencial.Senha, usuario.Senha)) {
          return NotFound(new { message = "Usuário ou senha inválidos" });
        }

        // Gera o Token
        var token = TokenService.GerarToken(usuario);

        return new {
          usuario = usuario,
          token = token
        };
      }



        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UserId)
            {
                return BadRequest();
            }
            
            usuario.Senha = SenhaService.GerarHash(usuario.Senha);
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {

            usuario.Senha = SenhaService.GerarHash(usuario.Senha);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.UserId }, usuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UserId == id);
        }
    }
}
