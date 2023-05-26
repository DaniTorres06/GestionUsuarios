using ServiceUsuarios;

namespace UsuariosMVC.Models
{
    public class FormularioViewModel
    {  

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Sexo { get; set; }
    }
}
