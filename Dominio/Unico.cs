using Dominio;
using System;

public class Unico : Pago
{
    public DateTime FechaDePago { get; set; }
    public int NumeroDeRecibo { get; set; }
    public Unico(DateTime unaFecha, int unNumeroDeRecibo,TipoDePago FormaDePago, TipoDeGasto unTipo, double monto, Usuario usuario) : base (FormaDePago, unTipo, monto, usuario)    
    {
        FechaDePago = unaFecha;
        NumeroDeRecibo = unNumeroDeRecibo;
        Descuento();
    }

    public override string ToString()
    {
        string resultado = base.ToString();
        resultado += "Unico";
            return resultado;
    }



    public void Descuento() {
    if (FormaDePago == TipoDePago.EFECTIVO)
        {
            Monto = Monto * (0.80);
        }
        else
        {
            Monto = Monto * (0.90);
        }
    }

    public override bool EntreFecha(DateTime fecha)
    {
        return (fecha.Year == FechaDePago.Year && fecha.Month == FechaDePago.Month) ;
    }

    public override DateTime fechaDePago()
    {
        return FechaDePago;
    }
}

