using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccesLayer;
using DataAccesLayer.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasContactosTiposController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonasContactosTiposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PersonasContactosTipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personas_Contactos_Tipos>>> GetPersonas_Contactos_Tipos()
        {
            return await _context.Personas_Contactos_Tipos.ToListAsync();
        }

        // GET: api/PersonasContactosTipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personas_Contactos_Tipos>> GetPersonas_Contactos_Tipos(long id)
        {
            var personas_Contactos_Tipos = await _context.Personas_Contactos_Tipos.FindAsync(id);

            if (personas_Contactos_Tipos == null)
            {
                return NotFound();
            }

            return personas_Contactos_Tipos;
        }

        // PUT: api/PersonasContactosTipos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonas_Contactos_Tipos(long id, Personas_Contactos_Tipos personas_Contactos_Tipos)
        {
            if (id != personas_Contactos_Tipos.Id_PerContTipo)
            {
                return BadRequest();
            }

            _context.Entry(personas_Contactos_Tipos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Personas_Contactos_TiposExists(id))
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

        // POST: api/PersonasContactosTipos
        [HttpPost]
        public async Task<ActionResult<Personas_Contactos_Tipos>> PostPersonas_Contactos_Tipos(Personas_Contactos_Tipos personas_Contactos_Tipos)
        {
            _context.Personas_Contactos_Tipos.Add(personas_Contactos_Tipos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonas_Contactos_Tipos", new { id = personas_Contactos_Tipos.Id_PerContTipo }, personas_Contactos_Tipos);
        }

        // DELETE: api/PersonasContactosTipos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Personas_Contactos_Tipos>> DeletePersonas_Contactos_Tipos(long id)
        {
            var personas_Contactos_Tipos = await _context.Personas_Contactos_Tipos.FindAsync(id);
            if (personas_Contactos_Tipos == null)
            {
                return NotFound();
            }

            _context.Personas_Contactos_Tipos.Remove(personas_Contactos_Tipos);
            await _context.SaveChangesAsync();

            return personas_Contactos_Tipos;
        }

        private bool Personas_Contactos_TiposExists(long id)
        {
            return _context.Personas_Contactos_Tipos.Any(e => e.Id_PerContTipo == id);
        }
    }
}
