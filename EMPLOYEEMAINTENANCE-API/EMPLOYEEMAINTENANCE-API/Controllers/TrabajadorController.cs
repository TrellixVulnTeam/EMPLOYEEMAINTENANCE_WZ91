using EMPLOYEEMAINTENANCE_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EMPLOYEEMAINTENANCE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {

        TrabajadorCon trabajadorCon = new TrabajadorCon();
        // GET: api/<TrabajadorController>
        [HttpGet]
        public IEnumerable<Trabajador> Get()
        {


            return trabajadorCon.Lists();

        }

        // GET api/<TrabajadorController>/5
        [HttpGet("{id}")]
        public ActionResult<Trabajador> Getid(int id)
        {
            var trabajador = trabajadorCon.BuscarPorID(id);
            if (trabajador == null)
            {

                return NotFound();
            }
            return trabajadorCon.BuscarPorID(id);
        }

        // POST api/<TrabajadorController>
        [HttpPost]
        public ActionResult Post([FromBody] Trabajador model)
        {
            if (model != null)
            {

                trabajadorCon.Añadir(model);
            }

            return CreatedAtAction("Getid", new { id = model.Trabajadorid }, model);


        }

        // PUT api/<TrabajadorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Trabajador model)
        {
            if (id != model.Trabajadorid)
            {
                return BadRequest();
            }
            if (model == null)
            {
                trabajadorCon.Actualizar(model, id);

            }
            return NoContent();
        }

        // DELETE api/<TrabajadorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var trabajador = trabajadorCon.BuscarPorID(id);
            if (trabajador == null)
            {

                return NotFound();
            }


            trabajadorCon.Borrar(id);
            return NoContent();

        }
    }
}
