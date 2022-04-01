
using greengroce.Logic;
using greengroce.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace greengroce.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        ValidateFruta objValida = new ValidateFruta();
        public AppDbContext dbContext { get; set; }
        private IHostingEnvironment Environment;
        public HomeController(IHostingEnvironment _environment)
        {
            Environment = _environment;
            dbContext = new AppDbContext();
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile files)
        {
            var postedFile = files;
            if (postedFile != null)
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                string csvData = System.IO.File.ReadAllText(filePath);
                DataTable dt = new DataTable("Frutas");
                bool firstRow = true;
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            if (firstRow)
                            {
                                foreach (string cell in row.Split(','))
                                {
                                    dt.Columns.Add(cell.Trim());
                                }
                                firstRow = false;
                                
                            }
                            else
                            {
                                Fruta Fruta = new Fruta();
                                var rowsfrutas = row.Split(',');
                                Fruta.Nombre = rowsfrutas[0];
                                Fruta.KgPrice = Convert.ToDecimal(rowsfrutas[1]);
                                Fruta.HkgPrice = Convert.ToDecimal(rowsfrutas[2]);
                                Fruta.DozenPrice = Convert.ToDecimal(rowsfrutas[3]);
                                objValida = new ValidateFruta(Fruta);
                                objValida.Insert();
                            }
                        }
                    }
                }
                return RedirectToAction("Index","Home");
            }

            return RedirectToAction("Index", "Home");
        }
    

        public FileResult Download()
        {
            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            string filePath = Path.Combine(path, "frutas.csv");
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            string fileName = "frutas.csv";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }




    }
}
