﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shared.Entities;

namespace DataAccesLayer.Models
{
    internal class Personas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id_Persona { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string PrimerNombre { get; set; }

        [MaxLength(128)]
        public string SegundoNombre { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string PrimerApellido { get; set; }

        [MaxLength(128)]
        public string SegundoApellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [MaxLength(128)]
        public string Documento { get; set; }

        public Persona GetEntity()
        {
            return new Persona()
            {
                Documento = Documento,
                FechaNacimiento = FechaNacimiento,
                Id_Persona = Id_Persona,
                PrimerApellido = PrimerApellido,
                PrimerNombre = PrimerNombre,
                SegundoApellido = SegundoApellido,
                SegundoNombre = SegundoNombre
            };
        }

        public static Personas GetEntityToSave(Persona x)
        {
            return new Personas()
            {
                Documento = x.Documento,
                FechaNacimiento = x.FechaNacimiento,
                Id_Persona = x.Id_Persona,
                PrimerApellido = x.PrimerApellido,
                PrimerNombre = x.PrimerNombre,
                SegundoApellido = x.SegundoApellido,
                SegundoNombre = x.SegundoNombre
            };
        }
    }
}