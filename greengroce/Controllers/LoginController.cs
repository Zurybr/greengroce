using greengroce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace greengroce.Controllers
{
    public class LoginController : Controller
    {
        public AppDbContext dbContext { get; set; }

        public LoginController()
        {
            dbContext = new AppDbContext();
        }
        //Boolean isAuthenticated = Setting.httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        public IActionResult Index()
        {
            var enc = Encoding.GetEncoding(0);
            byte[] buffer = enc.GetBytes("Mexico00");
            var sha1 = SHA1.Create();
            var hash = BitConverter.ToString(sha1.ComputeHash(buffer)).Replace("-", "");
            var alg = hash == dbContext.Usuarios.First().Password;
            //if (isAuthenticated)
            //    return View(@"~/Views/Seguridad/Index.cshtml");
            return View(@"~/Views/Seguridad/LogIn.cshtml");
        }
    }
}
