using System;

namespace XelaTech.Modelos
{
    public class ComputadoraEscritorio : Equipo
    {
        public string FactorForma { get; set; }

        public ComputadoraEscritorio(string codigo, string serie, string marca, string modelo, Cliente propietario, string estado, string accesorios, string factorForma)
            : base(codigo, serie, marca, modelo, propietario, estado, accesorios, "Computadora de Escritorio")
        {
            FactorForma = factorForma;
        }

        public ComputadoraEscritorio(string codigo, string serie, string marca, string modelo, Cliente propietario, string estado, string accesorios, bool esGamer)
            : base(codigo, serie, marca, modelo, propietario, estado, accesorios, "Computadora de Escritorio")
        {
            FactorForma = esGamer ? "Gamer / Torre" : "Estándar";
        }

        public override double CalcularCostoRevision() => 90.00;
    }
}