using greengroce.Logic;
using greengroce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace greengroce.Controllers
{
    
    public class FrutaController : Controller
    {
        ValidateFruta objValida = new ValidateFruta();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PagFive()
        {

            return View(objValida.Get(new Fruta()));
       
        }
    }
}
