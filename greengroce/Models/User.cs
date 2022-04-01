using System;
using System.Collections.Generic;

#nullable disable

namespace greengroce.Models
{
    public partial class User
    {
        public short IdUsuario { get; set; }
        public string Username { get; set; }
        public string Hash { get; set; }
        public string Email { get; set; }
    }
}
