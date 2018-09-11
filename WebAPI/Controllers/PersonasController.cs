using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Personas")]
    [Authorize(Roles = "USER")]
    public class PersonasController : Controller
    {
        private IBL_Personas bl;

        public PersonasController(IBL_Personas _bl)
        {
            bl = _bl;
        }

        // GET: api/Personas
        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            return bl.GetAll();
        }

        // GET: api/Personas/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(long id)
        {
            Persona result = bl.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        
        // POST: api/Personas
        [HttpPost]
        public IActionResult Post([FromBody]Persona x)
        {
            try
            {
                Persona result = bl.Add(x);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch(Exception ex)
            {
                // TODO Retornar error interno.
                return NotFound(ex.Message);
            }
        }
        
        // PUT: api/Personas/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Persona x)
        {
            try
            {
                Persona result = bl.Update(x);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                // TODO Retornar error interno.
                return NotFound(ex.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
