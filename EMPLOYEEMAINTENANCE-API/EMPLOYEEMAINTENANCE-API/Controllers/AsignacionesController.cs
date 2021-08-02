using EMPLOYEEMAINTENANCE_API.Models;
using EMPLOYEEMAINTENANCE_API.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EMPLOYEEMAINTENANCE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesController : ControllerBase
    {
        IAsignacionesCon _asignacionesCon;
        public AsignacionesController(IAsignacionesCon asignacionesCon)
        {
            _asignacionesCon = asignacionesCon;
        }
        // GET: api/<AsignacionesController>
        [HttpGet]
        public IEnumerable<AsignacionesaActualizarDTO> Get()
        {
            return _asignacionesCon.Lists();
        }

        // GET api/<AsignacionesController>/5
        [HttpGet("{id}")]
        public ActionResult <AsignacionesaActualizarDTO> GetId(int id)
        {
            var asignacion = _asignacionesCon.BuscarPorID(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            return _asignacionesCon.BuscarPorID(id);
        }

        // POST api/<AsignacionesController>
        [HttpPost]
        public ActionResult Post([FromBody] AsignacionesaAgregarDTO model)
        {
            var res = false;
            if (model != null)
            {
               res= _asignacionesCon.Añadir(model);
            }
            if (!res)
            {
                return StatusCode(500);
            }
            return Ok(model);

        }

        // PUT api/<AsignacionesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AsignacionesaActualizarDTO model)
        {
            var res = false;

            if (id != model.Asignacionid)
            {
                return BadRequest();
            }
            if (model != null)
            {
              res =  _asignacionesCon.Actualizar(model, id);
            }
            if (!res)
            {
                return StatusCode(500);
            }
            return NoContent();
        }

        // DELETE api/<AsignacionesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool res;

            var asignacion = _asignacionesCon.BuscarPorID(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            res =  _asignacionesCon.Borrar(id);

            if (!res)
            {
                return StatusCode(500);
            }
            return NoContent();
        }
    }
}
