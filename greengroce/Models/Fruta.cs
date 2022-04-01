using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace greengroce.Models
{
    public partial class Fruta
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short IdFruta { get; set; }
        public string ClaveFruta { get; set; }
        public string Nombre { get; set; }
        public decimal? KgPrice { get; set; }
        public decimal? HkgPrice { get; set; }
        public decimal? DozenPrice { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool? Status { get; set; }
        public bool? IsDelete { get; set; }
    }
}
