using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.DTOs
{
    public class RegistroDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 4)]
        public string Password { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Apellidos { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Nombres { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Documento { get; set; }
    }
}
