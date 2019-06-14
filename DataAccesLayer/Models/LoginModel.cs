using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Models
{
    public class LoginModel
    {
        public string token { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Documento { get; set; }
    }
}
