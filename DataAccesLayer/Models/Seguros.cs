using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccesLayer.Models
{
    public class Seguros
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id_DeSeguro { get; set; }

        public Cliente Cliente { get; set; }

        public TipoDeSeguro Tipo { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFechaFin { get; set; }

        [MaxLength(128)]
        public string Titulo { get; set; }

        [MaxLength(2048)]
        public string Descripccion { get; set; }

        [MaxLength(Int32.MaxValue)]
        public string DocumentoPDF { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal CostoTotal { get; set; }
    }
}
