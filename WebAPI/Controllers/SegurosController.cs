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
using Microsoft.AspNetCore.Identity;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public SegurosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Seguros
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<IEnumerable<Seguros>>> GetSeguros()
        {
            try
            {
                return await _context.Seguros
                                     .Include(x => x.Cliente)
                                     .Include(x => x.Tipo)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Seguros/Clientes
        [HttpGet("Clientes")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult<IEnumerable<ClienteDTO>> GetClientes(string filtro = "")
        {
            try
            {
                var aux = _context.Clientes.ToList();

                List<ClienteDTO> result = new List<ClienteDTO>();

                aux.ForEach(x => 
                    result.Add(new ClienteDTO() { Id = x.Id_Cliente,
                                                  Documento = x.Documento,
                                                  Nombre = x.Apellidos.Trim() + ", " + x.Nombres.Trim()
                                                })
                    );

                result = result.Where(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Documento.ToUpper().Contains(filtro.ToUpper())).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Seguros
        [HttpGet("misseguros")]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult<IEnumerable<Seguros>>> GetMisSeguros()
        {
            try
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                Cliente c = _context.Clientes.FirstOrDefault(x => x.Usuario == user.Email);
                if (c == null)
                    throw new Exception("No existe un cliente con email " + user.Email);
                
                return await _context.Seguros
                                     .Where(x => x.Cliente.Id_Cliente == c.Id_Cliente)
                                     .Include(x => x.Cliente)
                                     .Include(x => x.Tipo)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Seguros/5
        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Seguros>> GetSeguros(long id)
        {
            try
            {
                var seguros = await _context
                                    .Seguros
                                    .Where(x => x.Id_DeSeguro == id)
                                     .Include(x => x.Cliente)
                                     .Include(x => x.Tipo)
                                     .FirstOrDefaultAsync();
                if (seguros == null)
                    throw new Exception("No existe ningún seguro con id " + id);

                return seguros;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Seguros/5
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> PutSeguros(long id, SeguroDTO seguros)
        {
            try
            {
                if (id != seguros.Id_DeSeguro)
                {
                    return BadRequest();
                }

                Seguros aux = _context.Seguros.Find(id);
                if (aux == null)
                    throw new Exception("No existe un seguro con id " + seguros.Id_DeSeguro);

                Cliente c = _context.Clientes.Find(seguros.Id_Cliente);
                if (c == null)
                    throw new Exception("No existe un cliente con id " + seguros.Id_Cliente);

                TipoDeSeguro t = _context.TiposDeSeguros.Find(seguros.Id_Tipo);
                if (t == null)
                    throw new Exception("No existe un tipo de seguro con id " + seguros.Id_Tipo);

                aux.Cliente = c;
                aux.Tipo = t;
                aux.CostoTotal = seguros.CostoTotal;
                aux.Descripccion = seguros.Descripccion;
                aux.DocumentoPDF = seguros.DocumentoPDFBase64;
                aux.FechaFechaFin = seguros.FechaFechaFin;
                aux.FechaInicio = seguros.FechaInicio;
                aux.Titulo = seguros.Titulo;

                _context.Entry(aux).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Ok(aux);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Seguros
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Seguros>> PostSeguros(SeguroDTO seguros)
        {
            try
            {
                Seguros aux = new Seguros();
                Cliente c = _context.Clientes.Find(seguros.Id_Cliente);
                if (c == null)
                    throw new Exception("No existe un cliente con id " + seguros.Id_Cliente);

                TipoDeSeguro t = _context.TiposDeSeguros.Find(seguros.Id_Tipo);
                if (t == null)
                    throw new Exception("No existe un tipo de seguro con id " + seguros.Id_Tipo);

                aux.Cliente = c;
                aux.Tipo = t;
                aux.CostoTotal = seguros.CostoTotal;
                aux.Descripccion = seguros.Descripccion;
                aux.DocumentoPDF = seguros.DocumentoPDFBase64;
                aux.FechaFechaFin = seguros.FechaFechaFin;
                aux.FechaInicio = seguros.FechaInicio;
                aux.Titulo = seguros.Titulo;
                
                _context.Seguros.Add(aux);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSeguros", new { id = aux.Id_DeSeguro }, aux);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/Seguros/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Seguros>> DeleteSeguros(long id)
        {
            try
            {
                var seguros = await _context.Seguros.FindAsync(id);
                if (seguros == null)
                {
                    return NotFound();
                }

                _context.Seguros.Remove(seguros);
                await _context.SaveChangesAsync();

                return seguros;

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private bool SegurosExists(long id)
        {
            return _context.Seguros.Any(e => e.Id_DeSeguro == id);
        }
    }
}
