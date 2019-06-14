using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccesLayer;
using DataAccesLayer.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeSegurosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TiposDeSegurosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TiposDeSeguros
        [HttpGet]
        [Authorize(Roles = "USER, ADMIN")]
        public async Task<ActionResult<IEnumerable<TipoDeSeguro>>> GetTiposDeSeguros()
        {
            return await _context.TiposDeSeguros.ToListAsync();
        }

        // GET: api/TiposDeSeguros/5
        [HttpGet("{id}")]
        [Authorize(Roles = "USER, ADMIN")]
        public async Task<ActionResult<TipoDeSeguro>> GetTipoDeSeguro(long id)
        {
            try
            {
                var tipoDeSeguro = await _context.TiposDeSeguros.FindAsync(id);

                if (tipoDeSeguro == null)
                {
                    return NotFound();
                }

                return tipoDeSeguro;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/TiposDeSeguros/5
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<TipoDeSeguro>> PutTipoDeSeguro(long id, TipoDeSeguro tipoDeSeguro)
        {
            try
            {
                if (id != tipoDeSeguro.Id_TipoDeSeguro)
                {
                    return BadRequest();
                }

                _context.Entry(tipoDeSeguro).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return tipoDeSeguro;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/TiposDeSeguros
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<TipoDeSeguro>> PostTipoDeSeguro(TipoDeSeguro tipoDeSeguro)
        {
            try
            {
                _context.TiposDeSeguros.Add(tipoDeSeguro);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTipoDeSeguro", new { id = tipoDeSeguro.Id_TipoDeSeguro }, tipoDeSeguro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/TiposDeSeguros/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<TipoDeSeguro>> DeleteTipoDeSeguro(long id)
        {
            try
            {
                var tipoDeSeguro = await _context.TiposDeSeguros.FindAsync(id);
                if (tipoDeSeguro == null)
                {
                    return NotFound();
                }

                _context.TiposDeSeguros.Remove(tipoDeSeguro);
                await _context.SaveChangesAsync();

                return tipoDeSeguro;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "ADMIN")]
        private bool TipoDeSeguroExists(long id)
        {
            try
            {
                return _context.TiposDeSeguros.Any(e => e.Id_TipoDeSeguro == id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
