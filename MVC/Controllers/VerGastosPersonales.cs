using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class VerGastosPersonales : Controller
    {

    Sistema miSistema = Sistema.Instancia;
        public IActionResult VerGastosPropios()
        {
            int id = (int)HttpContext.Session.GetInt32("UsuarioId");
            Usuario u = miSistema.ObtenerUsuariobyID(id);
            List<Pago>PagosUsuario= miSistema.ListarPagos(u);

            return View(PagosUsuario);
        }
    }
}
