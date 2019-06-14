using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccesLayer.Models
{
    public class TipoDeSeguro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id_TipoDeSeguro { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Nombre { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Color { get; set; }

        public TipoDeSeguro()
        {

        }
    }
}
