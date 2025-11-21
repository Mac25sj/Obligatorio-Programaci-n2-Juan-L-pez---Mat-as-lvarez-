using Dominio;
using Dominio.Interfacez;
using System;
using System.Security.Cryptography;

public class Recurrente : Pago
{
    public DateTime FechaDeInicio { get; set; }
    public DateTime FechaDeFinal { get; set; }

    public Recurrente(DateTime unaFechaDeinicio, DateTime unaFechaFinal, TipoDePago FormaDePago, TipoDeGasto TipoGasto , double monto, Usuario usuario) : base (FormaDePago, TipoGasto , monto, usuario)
    {
        FechaDeInicio = unaFechaDeinicio;
        FechaDeFinal = unaFechaFinal;
        montoFinal();
     
    }

    public override string ToString()
    {
        string resultado = base.ToString();
        resultado += $"Fecha de Inicio {FechaDeInicio} + Fecha de Final {FechaDeFinal} + Cuotas pendientes {CuotasPendientes(FechaDeInicio, FechaDeFinal)}";
        return resultado;
    }

    public override void Validar()
    {
        base.Validar();
        ValidarFechas();
    }

    private void ValidarFechas()
    {
        if (FechaDeInicio == DateTime.MinValue) throw new Exception("Las fecha de Inicio no puede ser nula");
        if (FechaDeInicio > FechaDeFinal) throw new Exception("La fecha de inicio no puede ser mayor a la fecha final");
    }

    public int CuotasPendientes(DateTime fechaInicial, DateTime fechaFinal)
    {
        int resultado = 0;
        
        while (fechaInicial <=fechaFinal)
        {
            if ( fechaInicial>DateTime.Now && fechaInicial < fechaFinal){
                resultado++;
                
            }
            fechaInicial = fechaInicial.AddMonths(1);
        }
        return resultado;
    }


    public void montoFinal()
    {
        if (FechaDeFinal == DateTime.MaxValue)
        {
            Monto = Monto - (Monto * 0.03);
        }
        else if (CuotasPendientes(FechaDeInicio, FechaDeFinal)>= 10){
            Monto = Monto - (Monto * 0.10);
        } else if (CuotasPendientes(FechaDeInicio, FechaDeFinal) >= 6 && CuotasPendientes(FechaDeInicio, FechaDeFinal) <= 9){
            Monto = Monto - (Monto * 0.05);
        } else if (CuotasPendientes(FechaDeInicio, FechaDeFinal) <= 5){
            Monto = Monto - (Monto * 0.03);


        }
    }

    public override bool EntreFecha(DateTime fecha)
    {

        return (fecha > FechaDeInicio && fecha < FechaDeFinal);
    }

    public override DateTime fechaDePago()
    {
        DateTime primerDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        if (primerDiaMes < FechaDeInicio)
        {
            return FechaDeInicio;
        }

        if (primerDiaMes > FechaDeFinal)
        {
            return FechaDeFinal;
        }

        return primerDiaMes;
    }
}


