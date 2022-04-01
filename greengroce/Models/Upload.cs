using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace greengroce.Models
{
    public partial class FrutaUpload
    {
        public string Nombre { get; set; }
        public decimal? KgPrice { get; set; }
        public decimal? HkgPrice { get; set; }
        public decimal? DozenPrice { get; set; }
    }
}
