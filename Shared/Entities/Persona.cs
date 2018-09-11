using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Entities
{
    public class Persona
    {
        public long Id_Persona { get; set; }

        [MaxLength(128, ErrorMessageResourceName = "El largo maximo del primer nombre debe ser de 128 caracteres."), 
         MinLength(3, ErrorMessageResourceName = "El largo mínimo del primer nombre debe ser de 3 caracteres."), 
         Required]
        public string PrimerNombre { get; set; }

        [MaxLength(128, ErrorMessageResourceName = "El largo maximo del segundo nombre debe ser de 128 caracteres.")]
        public string SegundoNombre { get; set; }

        [MaxLength(128, ErrorMessageResourceName = "El largo maximo del primer apellido debe ser de 128 caracteres."),
         MinLength(3, ErrorMessageResourceName = "El largo mínimo del primer apellido debe ser de 3 caracteres."),
         Required]
        public string PrimerApellido { get; set; }

        [MaxLength(128, ErrorMessageResourceName = "El largo maximo del segundo apellido debe ser de 128 caracteres.")]
        public string SegundoApellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [MaxLength(128, ErrorMessageResourceName = "El largo maximo del documento debe ser de 128 caracteres.")]
        public string Documento { get; set; }

        [MaxLength(128, ErrorMessageResourceName = "El largo maximo del tipo de documento debe ser de 128 caracteres.")]
        public string TipoDocumento { get; set; }
    }
}
