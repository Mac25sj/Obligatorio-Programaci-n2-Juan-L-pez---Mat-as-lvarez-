using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        Sistema miSistema = Sistema.Instancia;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            bool bandera = HttpContext.Session.GetInt32("UsuarioId") != null;
           if (bandera) {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string contrasena)
        {
            Usuario usuario = miSistema.iniciarSesion(email, contrasena);

            if (usuario != null)
            {
                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
                HttpContext.Session.SetString("Nombre", usuario.Nombre);
                HttpContext.Session.SetString("Rol", usuario.Rol.ToString());

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Email o contraseña incorrectos.";
                HttpContext.Session.Clear();
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}