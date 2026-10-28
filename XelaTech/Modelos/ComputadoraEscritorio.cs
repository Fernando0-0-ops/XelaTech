namespace XelaTech.Modelos
{
    public class ComputadoraEscritorio : Equipo
    {
        public bool EsGamer { get; set; }

        public ComputadoraEscritorio(string codigoInterno, string numeroSerie, string marca, string modelo, Cliente propietario, string estadoFisico, string accesorios, bool esGamer)
            : base(codigoInterno, numeroSerie, marca, modelo, propietario, "Computadora Escritorio", estadoFisico, accesorios)
        {
            EsGamer = esGamer;
        }

        public override double CalcularCostoRevision() => EsGamer ? 100.00 : 60.00;
    }
}