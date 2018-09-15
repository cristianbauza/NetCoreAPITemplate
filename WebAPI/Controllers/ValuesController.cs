using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Shared.Entities;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public ILogger<ValuesController> Logger { get; }

        public ValuesController(ILogger<ValuesController> logger)
        {
            Logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Logger.LogInformation("Get Values");
            throw new Exception("Probando Excepcion.");
            return new string[] { "value1", "value2", "value3" };
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //[Authorize(Roles ="USER")]
        //public ActionResult Get(int id)
        //{
        //    Table1 result = new Table1() { Descripcion = "Prueba " + id.ToString(), Fecha = DateTime.Now, Activo = true };

        //    using (DataAccesLayer.ApplicationDbContext db = new DataAccesLayer.ApplicationDbContext())
        //    {
        //        db.Table1.Add(result);
        //        db.SaveChanges();
        //    }

        //    return Ok(result);
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
