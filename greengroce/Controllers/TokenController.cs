using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using greengroce.Models;
using Microsoft.AspNetCore.Mvc;

namespace greengroce.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        [HttpPost]
        //public IActionResult Post([FromBody]LoginModel loginModel)
        public IActionResult Post([FromBody] Usuario Usuario)
        {
            //var enc = Encoding.GetEncoding(0);
            //byte[] buffer = enc.GetBytes("Mexico00");
            //var sha1 = SHA1.Create();
            //var hash = BitConverter.ToString(sha1.ComputeHash(buffer)).Replace("-", "");
            if (Usuario.ClaveUsuario != "stephany" && Usuario.Password != "Mexico00")
                return Unauthorized();

            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("a-password-very-big-to-be-good"))
                                .AddSubject("Stehany Batista")
                                .AddIssuer("stephanybatista.com")
                                .AddAudience("stephanybatista.com")
                                .AddNameId("salmeidabatista@gmail.com")
                                .AddClaim("employeer", "31")
                                .AddExpiry(1)
                                .Build();

            return Ok(token);
        }       
    }
}
