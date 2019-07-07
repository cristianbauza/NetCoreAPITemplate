using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SeguroDTO
    {
        public long Id_DeSeguro { get; set; }

        public long Id_Cliente { get; set; }

        public long Id_Tipo { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFechaFin { get; set; }

        public string Titulo { get; set; }

        public string Descripccion { get; set; }

        public string DocumentoPDFBase64 { get; set; }

        public decimal CostoTotal { get; set; }
    }
}
