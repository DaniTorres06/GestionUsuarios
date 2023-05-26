using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceUsuarios
{
    public class UsuariosDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
    }
}