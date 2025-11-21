using Dominio.Interfacez;
using System;

namespace Dominio
{
    public class Usuario : IValidar,IComparable<Usuario>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }
        public Equipo Pertenece { get; set; }
        public DateTime IncorporacionEmpresa { get; set; }

        public rol Rol { get; set; }

        public Usuario(int id, string unNombre, string unApellido, string unaContrasena, string unEmail, Equipo unEquipo, DateTime fechaInicial,rol unrol)
        {
            Id= id;
            Nombre = unNombre;
            Apellido = unApellido;
            Contrasena = unaContrasena;
            Email = unEmail;
            Pertenece = unEquipo;
            IncorporacionEmpresa = fechaInicial;
            Rol = unrol;

        }
       
        public override bool Equals(object? obj)
        {
            if (obj is Usuario unUsuario)
            {
                return unUsuario.Email == this.Email;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Email != null ? Email.GetHashCode() : 0;
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new Exception("El nombre no puede ser nulo ni vacío.");
        }

        private void ValidarApellido()
        {
            if (string.IsNullOrWhiteSpace(Apellido))
                throw new Exception("El apellido no puede ser nulo ni vacío.");
        }

        private void ValidarContrasena()
        {
            if (string.IsNullOrWhiteSpace(Contrasena))
                throw new Exception("La contraseña no puede estar vacía.");
        }

        public  void Validar()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarContrasena();
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} - {Email} - Equipo: {Pertenece?.Nombre}";
        }
        public int CompareTo(Usuario? other)
        {
            if (Email.CompareTo(other.Email) > 0)
            {
                return 1;
            }
            else if (Email.CompareTo(other.Email) < 0)
            {
                return -1;

            }
            else return 0;
        }


    }





}