namespace XelaTech.Modelos
{
    public class Impresora : Equipo
    {
        public string TipoTinta { get; set; }

        public Impresora(string codigoInterno, string numeroSerie, string marca, string modelo, Cliente propietario, string estadoFisico, string accesorios, string tipoTinta)
            : base(codigoInterno, numeroSerie, marca, modelo, propietario, "Impresora", estadoFisico, accesorios)
        {
            TipoTinta = tipoTinta;
        }

        public override double CalcularCostoRevision() => 50.00;
    }
}