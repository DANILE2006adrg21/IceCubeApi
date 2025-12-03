using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IceCube.Context;   // 👈 usa el namespace donde está tu DbContext
using IceCube.Models;

namespace IceCube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuPerfilsController : ControllerBase
    {
        private readonly IceCube_Apicontext _context; 

        public UsuPerfilsController(IceCube_Apicontext context)
        {
            _context = context;
        }

        // GET: api/UsuPerfils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuPerfil>>> GetUsuPerfil()
        {
            return await _context.UsuPerfil.AsNoTracking().ToListAsync();
        }

        // GET: api/UsuPerfils/con-catalogo  (JOIN con CatIdioma)
        [HttpGet("con-catalogo")]
        public async Task<ActionResult<IEnumerable<UsuPerfil>>> GetUsuPerfilConCatalogo()
        {
            var data = await _context.UsuPerfil
                .Include(u => u.CatIdioma)
                .AsNoTracking()
                .ToListAsync();
            return Ok(data);
        }

        // GET: api/UsuPerfils/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuPerfil>> GetUsuPerfil(int id)
        {
            var usuPerfil = await _context.UsuPerfil.FindAsync(id);
            return usuPerfil is null ? NotFound() : usuPerfil;
        }

        // PUT: api/UsuPerfils/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutUsuPerfil(int id, UsuPerfil usuPerfil)
        {
            if (id != usuPerfil.id) return BadRequest("El id de la ruta no coincide.");

            _context.Entry(usuPerfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuPerfilExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/UsuPerfils
        [HttpPost]
        public async Task<ActionResult<UsuPerfil>> PostUsuPerfil(UsuPerfil usuPerfil)
        {
            _context.UsuPerfil.Add(usuPerfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuPerfil), new { id = usuPerfil.id }, usuPerfil);
        }

        // DELETE: api/UsuPerfils/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUsuPerfil(int id)
        {
            var usuPerfil = await _context.UsuPerfil.FindAsync(id);
            if (usuPerfil is null) return NotFound();

            _context.UsuPerfil.Remove(usuPerfil);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool UsuPerfilExists(int id) =>
            _context.UsuPerfil.Any(e => e.id == id);
    }
}
