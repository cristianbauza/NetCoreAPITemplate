using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccesLayer.Models
{
    public class Noticias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id_Noticia { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Titulo { get; set; }

        public DateTime FechaHora { get; set; }

        public bool Activa { get; set; }

        [MaxLength(Int32.MaxValue), MinLength(3)]
        public string Imagen { get; set; }
    }
}
