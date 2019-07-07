using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ClienteDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
    }
}
