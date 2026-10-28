namespace XelaTech.Modelos
{
    public class ComputadoraPortatil : Equipo
    {
        public bool IncluyeCargador { get; set; }

        public ComputadoraPortatil(string codigoInterno, string numeroSerie, string marca, string modelo, Cliente propietario, string estadoFisico, string accesorios, bool incluyeCargador)
            : base(codigoInterno, numeroSerie, marca, modelo, propietario, "Computadora Portátil", estadoFisico, accesorios)
        {
            IncluyeCargador = incluyeCargador;
        }

        public override double CalcularCostoRevision() => 75.00;
    }
}