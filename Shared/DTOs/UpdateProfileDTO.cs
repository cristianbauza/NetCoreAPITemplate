using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.DTOs
{
    public class UpdateProfileDTO
    {
        [MaxLength(128), MinLength(3), Required]
        public string Apellidos { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Nombres { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Documento { get; set; }
    }
}
