using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class CargarNuevoPago : Controller
    {
        Sistema miSistema = Sistema.Instancia;
        public IActionResult CargarUnPago()
        {

            return View(miSistema.obtenerListaTipoGasto());
        }

        [HttpPost]
        public IActionResult CargarUnPago(double Monto, string tipoPago, string Pago, string tipoDeGasto, DateTime? fechaUnica, DateTime? fechaInicio, DateTime? fechaFin, int NumeroDePago)
        {
            int id = (int)HttpContext.Session.GetInt32("UsuarioId");
            Usuario u = miSistema.ObtenerUsuariobyID(id);
            TipoDePago formaDePago;

            if (tipoPago == TipoDePago.DEBITO.ToString())
            {
                formaDePago = TipoDePago.DEBITO;

            }
            else if (tipoPago == TipoDePago.EFECTIVO.ToString())
            {
                formaDePago = TipoDePago.EFECTIVO;

            }
            else
            {
                formaDePago = TipoDePago.CREDITO;

            }


            if (fechaUnica != null)
            {
                Unico nuevo = new Unico(fechaUnica.Value, NumeroDePago, formaDePago, miSistema.obtenerPagoPorNombre(tipoDeGasto), Monto, u);
                miSistema.altaPagoUnico(nuevo);
                return View(miSistema.obtenerListaTipoGasto());

            }
            else if (fechaInicio != null && fechaFin != null)
            {
                Recurrente Nuevo = new Recurrente(fechaInicio.Value, fechaFin.Value, formaDePago, miSistema.obtenerPagoPorNombre(tipoDeGasto), Monto, u);
                miSistema.altaPagoRecurrente(Nuevo);
                return View(miSistema.obtenerListaTipoGasto());





            }
            return View(miSistema.obtenerListaTipoGasto());

        }

    //[HttpPost]
    //public IActionResult CargarUnPago2(double Monto, string tipoPago, string Pago, string tipoDeGasto, DateTime fechaInicio, DateTime fechaFin, int NumeroDePago)
    //{
    //    int id = (int)HttpContext.Session.GetInt32("UsuarioId");
    //    Usuario u = miSistema.ObtenerUsuariobyID(id);
    //    TipoDePago formaDePago;


    //    if (tipoPago == TipoDePago.DEBITO.ToString())
    //    {
    //        formaDePago = TipoDePago.DEBITO;

    //    }
    //    else if (tipoPago == TipoDePago.EFECTIVO.ToString())
    //    {
    //        formaDePago = TipoDePago.EFECTIVO;

    //    }
    //    else
    //    {
    //        formaDePago = TipoDePago.CREDITO;

    //    }
    //    Recurrente Nuevo = new Recurrente(fechaInicio, fechaFin, formaDePago, miSistema.obtenerPagoPorNombre(tipoDeGasto), Monto, u);

    //    miSistema.altaPagoRecurrente(Nuevo);
    //    return View(miSistema.obtenerListaTipoGasto());
    //}






}
}
