using EMPLOYEEMAINTENANCE_API.DTO;
using EMPLOYEEMAINTENANCE_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMPLOYEEMAINTENANCE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdificiosController : ControllerBase
    {
        IEdificiosCon _edificiosCon;
        public EdificiosController(IEdificiosCon edificiosCon)
        {
            _edificiosCon = edificiosCon;
        }
        // GET: api/<EdificiosController>
        [HttpGet]
        public IEnumerable<EdificiosActualizarDTO> Get()
        {
            return _edificiosCon.Lists();
        }

        // GET api/<EdificiosController>/5
        [HttpGet("{id}")]
        public ActionResult <EdificiosActualizarDTO> GetId(int id)
        {
            var edificios = _edificiosCon.BuscarPorID(id);
            if (edificios == null)
            {
                return NotFound();
            }
            return _edificiosCon.BuscarPorID(id);
        }

        // POST api/<EdificiosController>
        [HttpPost]
        public ActionResult Post([FromBody] EdificiosAgregarDTO model)
        {
            var res = false;

            if (model !=null)
            {
               res= _edificiosCon.Añadir(model);
            }

            if (!res)
            {
                return StatusCode(500);
            }
            return Ok(model);
        }

        // PUT api/<EdificiosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EdificiosActualizarDTO model)
        {
            var res = false;

            if (id != model.EdificiosId)
            {
                return BadRequest();
            }
            if (model != null)
            {
               res= _edificiosCon.Actualizar(model, id);
            }

            if (!res)
            {
                return StatusCode(500);
            }
            return NoContent();
        }

        // DELETE api/<EdificiosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool res;

            var edificios = _edificiosCon.BuscarPorID(id);
            if (edificios == null)
            {
                return NotFound();
            }

           res= _edificiosCon.Borrar(id);


            if (!res)
            {
                return StatusCode(500);
            }
            return NoContent();
        }
    }
}
