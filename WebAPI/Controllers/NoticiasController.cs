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
    public class NoticiasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NoticiasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Noticias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Noticias>>> GetNoticias()
        {
            try
            {
                return await _context.Noticias.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Noticias
        [HttpGet("activas")]
        public async Task<ActionResult<IEnumerable<Noticias>>> GetNoticiasActivas()
        {
            try
            {
                return await _context.Noticias.Where(x => x.Activa).ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Noticias/5
        [HttpGet("{id}")]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult<Noticias>> GetNoticias(long id)
        {
            try
            {
                var noticias = await _context.Noticias.FindAsync(id);

                if (noticias == null)
                {
                    return NotFound();
                }

                return Ok(noticias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Noticias/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Noticias>> PutNoticias(long id, Noticias noticias)
        {
            try
            {
                if (id != noticias.Id_Noticia)
                {
                    return BadRequest();
                }

                Noticias aux = _context.Noticias.Find(id);

                if (aux == null)
                    throw new Exception("No existe una noticia con id " + id);

                noticias.FechaHora = aux.FechaHora;
                _context.Entry(noticias).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Ok(noticias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Noticias
        [HttpPost]
        public async Task<ActionResult<Noticias>> PostNoticias(Noticias noticias)
        {
            try
            {
                noticias.FechaHora = DateTime.Now;
                _context.Noticias.Add(noticias);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetNoticias", new { id = noticias.Id_Noticia }, noticias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/Noticias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Noticias>> DeleteNoticias(long id)
        {
            try
            {
                var noticias = await _context.Noticias.FindAsync(id);
                if (noticias == null)
                {
                    return NotFound();
                }

                _context.Noticias.Remove(noticias);
                await _context.SaveChangesAsync();

                return noticias;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private bool NoticiasExists(long id)
        {
            try
            {
                return _context.Noticias.Any(e => e.Id_Noticia == id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
