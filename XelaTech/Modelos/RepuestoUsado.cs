using System;

namespace XelaTech.Modelos
{
    public class RepuestoUsado
    {
        public Repuesto RepuestoAsociado { get; set; }

        // Alias para compatibilidad con el reporte de Excel que ya tenías
        public Repuesto RepuestoInfo
        {
            get { return RepuestoAsociado; }
            set { RepuestoAsociado = value; }
        }

        public int CantidadUsada { get; set; }

        // Alias para compatibilidad con la cantidad que ya manejaba tu código
        public int Cantidad
        {
            get { return CantidadUsada; }
            set { CantidadUsada = value; }
        }

        public double Subtotal
        {
            get { return RepuestoAsociado != null ? RepuestoAsociado.PrecioVenta * CantidadUsada : 0; }
        }

        public RepuestoUsado(Repuesto repuesto, int cantidad)
        {
            RepuestoAsociado = repuesto;
            CantidadUsada = cantidad;
        }
    }
}