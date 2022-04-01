using System;
using Microsoft.AspNetCore.Mvc;
using greengroce.Logic;
using greengroce.Models;

namespace greengroce.ApiControllers
{
    [ApiController]
    [Route("Api/[controller]/[Action]")]
    public class FrutaController : ControllerBase
    {
        ValidateFruta objValida = new ValidateFruta();

        [HttpGet]
        public IActionResult Get()
        {
            //return Search(new Fruta());
            return Ok(objValida.Get());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(short id)
        {
            //return Search(new Fruta());
            return Ok(objValida.GetById(id));
        }

        [HttpGet]
        public IActionResult GetActivos()
        {
            try
            {
                return Search(new Fruta());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Search([FromBody] Fruta model)
        {
            try
            {
                return Ok(objValida.Get(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }       

        [HttpPost]
        public IActionResult Post([FromBody] Fruta Fruta)
        {
            try
            {
                objValida = new ValidateFruta(Fruta);
                return Ok(objValida.Insert());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Fruta Fruta)
        {
            try
            {
                objValida = new ValidateFruta(Fruta);
                return Ok(objValida.Update());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            try
            {
                objValida.Delete(id);
                return Ok(id.ToString() +" ha sido eliminado satisfactoriamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}