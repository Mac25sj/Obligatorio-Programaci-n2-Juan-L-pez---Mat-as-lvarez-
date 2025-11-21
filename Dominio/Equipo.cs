using Dominio.Interfacez;
using System;

public class Equipo: IValidar
{
        public int Id { get; set; }
    public string Nombre { get; set; }
    public static int ProximoId { get; set; } = 1;

    public Equipo(string unNombre)
    {
        Id = ProximoId++;
        Nombre = unNombre;
    }

    public void Validar()
    {
        ValidarNombre();
    }

    private void ValidarNombre()
    {
        if (Nombre == null) throw new Exception("El nombre no puede ser nulo");

    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}";
    }
    public override bool Equals(object? obj)
    {
        return obj is Equipo unEquipo && unEquipo.Nombre == Nombre;
    }


    public bool EsMiEquipo(string nombreEquipo)
    {
if(nombreEquipo ==Nombre) return true;
        return false;
    }
}
