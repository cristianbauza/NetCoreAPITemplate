﻿using System;
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
            return await _context.Noticias.ToListAsync();
        }

        // GET: api/Noticias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Noticias>> GetNoticias(long id)
        {
            var noticias = await _context.Noticias.FindAsync(id);

            if (noticias == null)
            {
                return NotFound();
            }

            return noticias;
        }

        // PUT: api/Noticias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoticias(long id, Noticias noticias)
        {
            if (id != noticias.Id)
            {
                return BadRequest();
            }

            _context.Entry(noticias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiasExists(id))
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

        // POST: api/Noticias
        [HttpPost]
        public async Task<ActionResult<Noticias>> PostNoticias(Noticias noticias)
        {
            _context.Noticias.Add(noticias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNoticias", new { id = noticias.Id }, noticias);
        }

        // DELETE: api/Noticias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Noticias>> DeleteNoticias(long id)
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

        private bool NoticiasExists(long id)
        {
            return _context.Noticias.Any(e => e.Id == id);
        }
    }
}
