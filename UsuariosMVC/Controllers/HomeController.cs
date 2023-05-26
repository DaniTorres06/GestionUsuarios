using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using ServiceUsuarios;
using System.Diagnostics;
using UsuariosMVC.Models;
using UsuariosMVC.Models.DTOs;

namespace UsuariosMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IService1 _miServicioClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_miServicioClient = miServicioClient;
        }

        public IActionResult Index(Models.DTOs.UsuariosDTO formulario)
        {
            if (ModelState.IsValid)
            {
                ServiceReference1.UsuariosDTO vObjUsuario = new();

                vObjUsuario.Nombre = formulario.Nombre;
                vObjUsuario.FechaNacimiento = formulario.FechaNacimiento;
                vObjUsuario.Sexo = formulario.Sexo;

                Service1Client cliente = new();
                cliente.AgregarAsync(vObjUsuario);
                
                return RedirectToAction("Privacy", "Home");
            }           

            return View("Index", formulario);
        }

        public IActionResult Editar(Models.DTOs.UsuariosDTO formulario)
        {
            return View(formulario);
        }

        [HttpPost]
        public IActionResult SaveEdit(Models.DTOs.UsuariosDTO formulario)
        {
            if (ModelState.IsValid)
            {
                // Realiza la llamada al servicio WCF utilizando el cliente
                ServiceReference1.UsuariosDTO vObjUsuario = new();

                vObjUsuario.Id = formulario.Id;
                vObjUsuario.Nombre = formulario.Nombre;
                vObjUsuario.FechaNacimiento = formulario.FechaNacimiento;
                vObjUsuario.Sexo = formulario.Sexo;

                Service1Client cliente = new();
                cliente.ModificarAsync(vObjUsuario);
            }
            return RedirectToAction("Privacy", "Home");
        }

        public IActionResult Completado(String Nombre)
        {
            return View("Completado", Nombre);            
        }

        public IActionResult Privacy()
        {
            Service1Client cliente = new();

            List<Models.DTOs.UsuariosDTO> lstUsers = new();

            if (ModelState.IsValid)
            {
                var datos = cliente.ConsultarAsync();

                lstUsers = cliente.ConsultarAsync().Result.Select(x => new Models.DTOs.UsuariosDTO
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    FechaNacimiento = x.FechaNacimiento,
                    Sexo = x.Sexo
                }).ToList();

            }

            return View(lstUsers);
            
        }

        public IActionResult FrmUsuarios()
        {
            return View();
        }

        public IActionResult Guardar(Models.DTOs.UsuariosDTO vUsuario)
        {
            if (ModelState.IsValid)
            {
                // Realiza la llamada al servicio WCF utilizando el cliente
                ServiceReference1.UsuariosDTO dani = new();

                dani.Nombre = vUsuario.Nombre;
                dani.FechaNacimiento = vUsuario.FechaNacimiento;
                dani.Sexo = vUsuario.Sexo;

                Service1Client cliente = new();
                cliente.AgregarAsync(dani);

                // Puedes realizar alguna acción adicional o redireccionar a otra vista
                
            }
            return RedirectToAction("Privacy", "Home");
        }

        public IActionResult Eliminar(int id)
        {
            Service1Client cliente = new();
            cliente.EliminarAsync(id);
            return RedirectToAction("Privacy","Home"); 
        }

        public IActionResult Edit(int id)
        {
            Service1Client cliente = new();
            var usuarioReponse =  cliente.GetusuariosXIdAsync(id);
            Models.DTOs.UsuariosDTO vUserDto = new() { Id = usuarioReponse.Result.Id,
                Nombre = usuarioReponse.Result.Nombre,
                FechaNacimiento = usuarioReponse.Result.FechaNacimiento,
                Sexo = usuarioReponse.Result.Sexo
            };

            return RedirectToAction("Editar", "Home", vUserDto );

        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}