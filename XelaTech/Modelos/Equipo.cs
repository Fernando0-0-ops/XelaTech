namespace XelaTech.Modelos
{
    public abstract class Equipo
    {
        public string CodigoInterno { get; set; }
        public string NumeroSerie { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public Cliente Propietario { get; set; }
        public string TipoEquipo { get; set; }
        public string EstadoFisico { get; set; }
        public string Accesorios { get; set; }

        public Equipo(string codigoInterno, string numeroSerie, string marca, string modelo, Cliente propietario, string tipoEquipo, string estadoFisico, string accesorios)
        {
            CodigoInterno = codigoInterno;
            NumeroSerie = numeroSerie;
            Marca = marca;
            Modelo = modelo;
            Propietario = propietario;
            TipoEquipo = tipoEquipo;
            EstadoFisico = estadoFisico;
            Accesorios = accesorios;
        }

        // Método virtual obligatorio para permitir el polimorfismo en las clases hijas
        public virtual double CalcularCostoRevision()
        {
            return 50.00;
        }
    }
}