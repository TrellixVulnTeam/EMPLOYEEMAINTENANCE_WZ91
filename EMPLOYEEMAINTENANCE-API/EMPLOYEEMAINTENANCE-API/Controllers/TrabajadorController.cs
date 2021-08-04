using EMPLOYEEMAINTENANCE_API.DTO;
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
        ITrabajadorCon _trabajadorCon;
        public TrabajadorController(ITrabajadorCon trabajadorCon)
        {
            _trabajadorCon = trabajadorCon;
        }
        // GET: api/<TrabajadorController>
        [HttpGet]
        public IEnumerable<TrabajadorActualizarDTO> Get()
        {


            return _trabajadorCon.Lists();

        }

        [HttpGet]
        [Route("getclean")]
        public IEnumerable<TrabajadorActualizarDTO> Getclean()
        {


            return _trabajadorCon.ListsClean();

        }

        // GET api/<TrabajadorController>/5
        [HttpGet("{id}")]
        public ActionResult<TrabajadorActualizarDTO> GetId(int id)
        {
            var trabajador = _trabajadorCon.BuscarPorID(id);
            if (trabajador == null)
            {

                return NotFound();
            }
            return _trabajadorCon.BuscarPorID(id);
        }

        // POST api/<TrabajadorController>
        [HttpPost]
        public ActionResult Post([FromBody] TrabajadorAgregarDTO model)
        {
            var res = false;

            if (model != null)
            {

              res=  _trabajadorCon.Añadir(model);
            }
            if (!res)
            {
                return StatusCode(500);
            }
            return Ok(model);


        }

        // PUT api/<TrabajadorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TrabajadorActualizarDTO model)
        {
            var res = false;

            if (id != model.Trabajadorid)
            {
                return BadRequest();
            }
            if (model != null)
            {
               res = _trabajadorCon.Actualizar(model, id);

            }
            if (!res)
            {
                return StatusCode(500);
            }
            return NoContent();
        }

        // DELETE api/<TrabajadorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool res;

            var trabajador = _trabajadorCon.BuscarPorID(id);
            if (trabajador == null)
            {

                return NotFound();
            }


            res = _trabajadorCon.Borrar(id);
            if (!res)
            {
                return StatusCode(500);
            }
            return NoContent();

        }
    }
}
