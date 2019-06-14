using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccesLayer.Models
{
    public class Consultas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id_Consulta { get; set; }

        public DateTime FechaHora { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Titulo { get; set; }

        [MaxLength(Int32.MaxValue), MinLength(0)]
        public string Consulta { get; set; }

        public bool ConsultaVista { get; set; }

        [MaxLength(Int32.MaxValue), MinLength(0)]
        public string Respuesta { get; set; }

        public bool RespuestaVista { get; set; }

        public string Usuario { get; set; }
    }
}
