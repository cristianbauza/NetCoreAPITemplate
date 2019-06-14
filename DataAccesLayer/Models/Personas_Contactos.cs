using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shared.Entities;

namespace DataAccesLayer.Models
{
    public class Personas_Contactos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id_PerCont { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Contacto { get; set; }

        public Personas Persona { get; set; }

        public Personas_Contactos_Tipos TipoContacto { get; set; }

        public PersonaContacto GetEntity()
        {
            return new PersonaContacto()
            {
                Id_PerCont = Id_PerCont,
                Contacto = Contacto
            };
        }
    }
}
