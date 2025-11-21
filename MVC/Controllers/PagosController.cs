using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;



    public class PagosController : Controller
{ 

    Sistema miSistema = Sistema.Instancia;
        public IActionResult VerPagos()
    {
        //Levantar al gerente
        int id = (int)HttpContext.Session.GetInt32("UsuarioId");
        Usuario u = miSistema.ObtenerUsuariobyID(id);

       ;
        return View(miSistema.ListarPagosPorFechayEquipo(u.Pertenece, DateTime.Now));


    }

    [HttpPost]
    public IActionResult VerPagos(DateTime FechaBuscada)
    {
       int id = (int)HttpContext.Session.GetInt32("UsuarioId");
       Usuario u = miSistema.ObtenerUsuariobyID(id);
        
        return View(miSistema.ListarPagosPorFechayEquipo(u.Pertenece, FechaBuscada));

    }

}




