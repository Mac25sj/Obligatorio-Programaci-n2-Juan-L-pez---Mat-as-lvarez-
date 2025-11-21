using Dominio;
using Dominio.Interfacez;
using System;

public abstract class Pago:IValidar
{
    public int Id { get; set; }
    public TipoDePago FormaDePago { get; set; }
public TipoDeGasto TipoGasto { get; set; } 


public Usuario NombreUsuario { get; set; }

 public double Monto  { get; set; }

    public static int ProximoId { get; set; } = 1;

    public Pago (TipoDePago unaFormaDePago,TipoDeGasto unTipo, double monto, Usuario usuario)
    {
        Id = ProximoId;
        ProximoId++;
        FormaDePago = unaFormaDePago;
        Monto = monto;
        NombreUsuario = usuario;
        TipoGasto = unTipo;
    }



    public override string ToString()
    {
        return $"ID: {Id}, Forma de Pago: {FormaDePago}, Monto: ${Monto}    , ";
        
    }

    //Llamado a la funciíon con clases heredadas
    
    public virtual void Validar()
    {
        ValidarMonto();
        validarUsuario();
        validarFormaDePago();
        validarTipoGasto(); 
    }

    private void validarTipoGasto()
    {
        if (TipoGasto == null) throw new Exception("El tipo de gasto no puede ser nulo ⚠️⚠️⚠️");
    }

    private void validarFormaDePago()
    {
        if (!Enum.IsDefined(typeof(TipoDePago), FormaDePago))
            throw new Exception("La forma de pago no es válida.");
    }

    private void validarUsuario()
    {
       if(NombreUsuario == null) throw new Exception("El usuario no puede ser nulo");
    }

    private void ValidarMonto()
    {
        if(Monto <= 0) throw new Exception("El monto debe ser mayor a positivo");
    }
    public bool esMiMail(string unEmail)
    {
        return NombreUsuario.Email == unEmail;
    }
    public abstract bool EntreFecha(DateTime fecha);
    public abstract DateTime fechaDePago();
    

    
}