using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace greengroce.Models
{
    public partial class Usuario
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short IdUsuario { get; set; }
        //[Required]
        //[Display(Name = "User name")]
        public string ClaveUsuario { get; set; }
        //[Required]
        //[Display(Name = "Password")]
        [ScaffoldColumn(false)]
        [JsonIgnore]
        public string Password { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? Status { get; set; }
        public bool? IsDelete { get; set; }
    }
}
