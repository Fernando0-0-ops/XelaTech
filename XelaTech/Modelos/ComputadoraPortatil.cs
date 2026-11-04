using System;

namespace XelaTech.Modelos
{
    public class ComputadoraPortatil : Equipo
    {
        public bool TieneBateriaDañada { get; set; }

        public ComputadoraPortatil(string codigo, string serie, string marca, string modelo, Cliente propietario, string estado, string accesorios, bool bateriaDañada)
            : base(codigo, serie, marca, modelo, propietario, estado, accesorios, "Computadora Portátil")
        {
            TieneBateriaDañada = bateriaDañada;
        }

        public ComputadoraPortatil(string codigo, string serie, string marca, string modelo, Cliente propietario, string estado, string accesorios, string bateriaDañadaStr)
            : base(codigo, serie, marca, modelo, propietario, estado, accesorios, "Computadora Portátil")
        {
            TieneBateriaDañada = bool.TryParse(bateriaDañadaStr, out bool res) && res;
        }

        public override double CalcularCostoRevision() => 75.00;
    }
}