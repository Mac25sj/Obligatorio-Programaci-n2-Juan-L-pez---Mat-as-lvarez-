using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class EliminarTipoGasto : Controller
    {
        Sistema miSistema = Sistema.Instancia;


        public IActionResult EliminarGasto()
        {

            return View(miSistema.obtenerListaTipoGasto());
        }

        [HttpPost]
        public IActionResult EliminarGasto(string idTipoGasto)
        {
            miSistema.BajaDePago(idTipoGasto);
            return View(miSistema.obtenerListaTipoGasto());

        }

    }
    
}
