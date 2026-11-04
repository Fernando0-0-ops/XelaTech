using System.Linq;

namespace XelaTech.Modelos
{
    public class Cliente : Persona
    {
        public string TipoCliente { get; set; }

        // Propiedad calculada dinámicamente para contar las solicitudes de este cliente
        public int CantidadSolicitudes
        {
            get
            {
                return DatosGlobales.ListaSolicitudes.Count(s => s.Cliente != null && s.Cliente.Codigo == this.Codigo);
            }
        }

        public Cliente(string codigo, string nombreCompleto, string telefono, string correo, string tipoCliente)
            : base(codigo, nombreCompleto, telefono, correo)
        {
            TipoCliente = tipoCliente;
        }

        public override string ObtenerInformacion()
        {
            return $"{base.ObtenerInformacion()} | Tipo: {TipoCliente} | Solicitudes: {CantidadSolicitudes}";
        }
        public override string ToString()
        {
            // Muestra el nombre completo (o el código, según prefieras)
            return NombreCompleto;
        }
    }
}