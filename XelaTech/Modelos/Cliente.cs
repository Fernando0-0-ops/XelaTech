namespace XelaTech.Modelos
{
    public class Cliente : Persona
    {
        public string TipoCliente { get; set; }
        public int CantidadSolicitudes { get; set; }

        public Cliente(string codigo, string nombreCompleto, string telefono, string correo, string tipoCliente)
            : base(codigo, nombreCompleto, telefono, correo)
        {
            TipoCliente = tipoCliente;
            CantidadSolicitudes = 0;
        }

        public override string ObtenerInformacion()
        {
            return $"{base.ObtenerInformacion()} | Tipo: {TipoCliente} | Solicitudes: {CantidadSolicitudes}";
        }
    }
}