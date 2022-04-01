using System;
using Microsoft.AspNetCore.Mvc;
using greengroce.Logic;
using greengroce.Models;

namespace greengroce.ApiControllers
{
    [ApiController]
    [Route("Api/[controller]/[Action]")]
    public class UsuarioController : ControllerBase
    {
        ValidateUsuario objValida = new ValidateUsuario();

        [HttpGet]
        public IActionResult Get()
        {
            //return Search(new Usuario());
            return Ok(objValida.Get());
        }

        [HttpGet]
        public IActionResult GetActivos()
        {
            try
            {
                return Search(new Usuario());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Search([FromBody] Usuario model)
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
        public IActionResult Post([FromBody] Usuario Usuario)
        {
            try
            {
                objValida = new ValidateUsuario(Usuario);
                return Ok(objValida.Insert());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Usuario Usuario)
        {
            try
            {
                objValida = new ValidateUsuario(Usuario);
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
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}