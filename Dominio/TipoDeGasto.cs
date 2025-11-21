using Dominio.Interfacez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoDeGasto : IValidar
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public TipoDeGasto(string unNombre, string unaDescripcion)
        {
            Nombre = unNombre;
            Descripcion = unaDescripcion;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Descripcion: {Descripcion}";
        }

        public void Validar()
        {
            validarTipoGasto();
        }

        private void validarTipoGasto()
        {
            if (Nombre == null || Descripcion == null)
                throw new Exception("Faltan llenar campos");
        }
    }
}