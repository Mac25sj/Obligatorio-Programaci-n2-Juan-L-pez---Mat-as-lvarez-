using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{

    public class AgregarPago : Controller
    {
        Sistema miSistema = Sistema.Instancia;

        public IActionResult NuevoPago()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NuevoPago(string NuevoTipoPago, string Descripcion)   
        {
            if (NuevoTipoPago != "" && !miSistema.ExisteTipoDeGasto(NuevoTipoPago))
            {
                
                miSistema.AltaGastosTipo(NuevoTipoPago, Descripcion);
                return RedirectToAction("NuevoPago", "AgregarPago");
            }
            else
            {
                return View();
            }
           

        }

    }
}
