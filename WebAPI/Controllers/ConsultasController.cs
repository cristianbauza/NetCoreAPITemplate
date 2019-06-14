using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccesLayer;
using DataAccesLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ConsultasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Consultas
        [HttpGet]
        [Authorize(Roles ="ADMIN")]
        public async Task<ActionResult<IEnumerable<Consultas>>> GetConsultas()
        {
            try
            {
                return await _context.Consultas.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Consultas/usuario
        [HttpGet("usuario")]
        public async Task<ActionResult<IEnumerable<Consultas>>> GetConsultasUsuario()
        {
            try
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                var consultas = _context.Consultas.Where(x => x.Usuario == user.Email).ToList();

                if (consultas == null)
                {
                    return NotFound();
                }

                return Ok(consultas);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Consultas/5
        [HttpPut("consultavista/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Consultas>> PutConsultaVista(long id)
        {
            try
            {
                Consultas aux = _context.Consultas.Find(id);

                if (aux == null)
                    return NotFound();

                aux.ConsultaVista = true;

                await _context.SaveChangesAsync();

                return Ok(aux);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Consultas/5
        [HttpPut("respuesta/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Consultas>> PutConsultaRespuesta(long id, [FromBody] Models.StringDTO respuesta)
        {
            try
            {
                Consultas aux = _context.Consultas.Find(id);

                if (aux == null)
                    return NotFound();

                aux.Respuesta = respuesta.Value;

                await _context.SaveChangesAsync();

                return Ok(aux);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Consultas/5
        [HttpPut("respuestavista/{id}")]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult<Consultas>> PutResupuestaVista(long id)
        {
            try
            {
                Consultas aux = _context.Consultas.Find(id);

                if (aux == null)
                    return NotFound();

                aux.RespuestaVista = true;

                var user = await _userManager.GetUserAsync(HttpContext.User);

                if (!user.Email.Equals(aux.Usuario))
                {
                    return Unauthorized();
                }

                await _context.SaveChangesAsync();

                return Ok(aux);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Consultas
        [HttpPost]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult<Consultas>> PostConsultas([FromBody] Models.ConsultaDTO consulta)
        {
            try
            {
                Consultas cons = new Consultas();
                cons.ConsultaVista = false;
                cons.Respuesta = "";
                cons.RespuestaVista = false;
                cons.Consulta = consulta.Consulta;
                cons.Titulo = consulta.Titulo;
                cons.FechaHora = DateTime.Now;

                var user = await _userManager.GetUserAsync(HttpContext.User);
                cons.Usuario = user.Email;

                _context.Consultas.Add(cons);

                await _context.SaveChangesAsync();

                return Ok(cons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private bool ConsultasExists(long id)
        {
            try
            {
                return _context.Consultas.Any(e => e.Id_Consulta == id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
