namespace ViewUsuarios.Models
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Sexo { get; set; }
    }
}
