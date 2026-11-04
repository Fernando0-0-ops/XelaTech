using System;

namespace XelaTech.Modelos
{
    public class Impresora : Equipo
    {
        public string TipoImpresora { get; set; }

        public Impresora(string codigo, string serie, string marca, string modelo, Cliente propietario, string estado, string accesorios, string tipoImpresora)
            : base(codigo, serie, marca, modelo, propietario, estado, accesorios, "Impresora")
        {
            TipoImpresora = tipoImpresora;
        }

        // Sobrecarga por si el formulario envía un valor booleano en lugar de texto
        public Impresora(string codigo, string serie, string marca, string modelo, Cliente propietario, string estado, string accesorios, bool aColor)
            : base(codigo, serie, marca, modelo, propietario, estado, accesorios, "Impresora")
        {
            TipoImpresora = aColor ? "Inyección a Color" : "Monocromática / Láser";
        }

        public override double CalcularCostoRevision() => 60.00;
    }
}