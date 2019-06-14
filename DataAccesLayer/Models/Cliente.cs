using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccesLayer.Models
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id_Cliente { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Apellidos { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Nombres { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Documento { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Usuario { get; set; }
    }
}
