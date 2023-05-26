using Microsoft.AspNetCore.Mvc;
using ServiceUsuarios;
using ViewUsuarios.Models;

namespace ViewUsuarios.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IService1 _miServicioClient;

        public UsuarioController(IService1 miServicioClient)
        {
            _miServicioClient = miServicioClient;
        }

        public IActionResult Index()
        {
            return View(new PrimeraPaginaModel());
        }
        [HttpPost]
        public IActionResult EnviarFormulario(UsuarioDTO formulario)
        {
            if (ModelState.IsValid)
            {
                // Realiza la llamada al servicio WCF utilizando el cliente
                UsuariosDTO Dani =new UsuariosDTO();
                Dani.Nombre = "Dani";
                Dani.FechaNacimiento = DateTime.Now;
                Dani.Sexo = 1;

                _miServicioClient.Agregar(Dani);

                // Puedes realizar alguna acción adicional o redireccionar a otra vista
                return RedirectToAction("Index");
            }

            return View("Index", formulario);
        }
    }
}
