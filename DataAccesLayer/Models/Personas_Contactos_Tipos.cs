using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccesLayer.Models
{
    internal class Personas_Contactos_Tipos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id_PerContTipo { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Nombre { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string RegExp { get; set; }
    }
}
