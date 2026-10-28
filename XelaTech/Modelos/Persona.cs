namespace XelaTech.Modelos
{
    public abstract class Persona
    {
        public string Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public Persona(string codigo, string nombreCompleto, string telefono, string correo)
        {
            Codigo = codigo;
            NombreCompleto = nombreCompleto;
            Telefono = telefono;
            Correo = correo;
        }

        public virtual string ObtenerInformacion()
        {
            return $"[{Codigo}] {NombreCompleto} - Tel: {Telefono}";
        }
    }
}