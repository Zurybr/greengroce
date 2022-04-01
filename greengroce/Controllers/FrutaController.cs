using Microsoft.AspNetCore.Mvc;
using System;

namespace greengroce.Controllers
{
    public class FrutaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Post([FromBody] string ClaveFruta)
        {
            try
            {

                //objValida = new ValidateFruta(Fruta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
