using System;
using System.Collections.Generic;

#nullable disable

namespace greengroce.Models
{
    public partial class Usuarios2
    {
        public short IdUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? Status { get; set; }
        public bool? IsDelete { get; set; }
    }
}
