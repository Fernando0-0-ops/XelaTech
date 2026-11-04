using System;

namespace XelaTech.Modelos
{
    public class Repuesto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int CantidadDisponible { get; set; }
        public int ExistenciaMinima { get; set; }
        public double CostoUnitario { get; set; }
        public double PrecioVenta { get; set; }

        /// <summary>
        /// Propiedad calculada que expone el estado visual del stock para el DataGridView.
        /// </summary>
        public string EstadoStock
        {
            get
            {
                if (EstaAgotado())
                    return "🔴 Agotado";
                else if (TienePocaExistencia())
                    return "⚠️ Crítico";
                else
                    return "🟢 Normal";
            }
        }

        public Repuesto(string codigo, string nombre, string categoria, int cantidadDisponible, int existenciaMinima, double costoUnitario, double precioVenta)
        {
            Codigo = codigo;
            Nombre = nombre;
            Categoria = categoria;
            CantidadDisponible = cantidadDisponible;
            ExistenciaMinima = existenciaMinima;
            CostoUnitario = costoUnitario;
            PrecioVenta = precioVenta;
        }

        /// <summary>
        /// Descuenta una cantidad específica del inventario validando que haya existencias suficientes.
        /// </summary>
        public bool DescontarStock(int cantidadAUsar)
        {
            if (cantidadAUsar <= 0) return false;

            if (CantidadDisponible >= cantidadAUsar)
            {
                CantidadDisponible -= cantidadAUsar;
                return true;
            }
            return false; // No hay suficiente stock
        }

        /// <summary>
        /// Retorna true si la cantidad disponible está en o por debajo del mínimo establecido.
        /// </summary>
        public bool TienePocaExistencia()
        {
            return CantidadDisponible <= ExistenciaMinima && CantidadDisponible > 0;
        }

        /// <summary>
        /// Retorna true si el repuesto está totalmente agotado.
        /// </summary>
        public bool EstaAgotado()
        {
            return CantidadDisponible <= 0;
        }
    }
}