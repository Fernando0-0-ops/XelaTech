using System;
using System.Collections.Generic;

namespace XelaTech.Modelos
{
    public class Solicitud
    {
        public string CodigoSolicitud { get; set; }

        public Cliente ClientePropietario { get; set; }
        public Cliente Cliente
        {
            get { return ClientePropietario; }
            set { ClientePropietario = value; }
        }

        public Equipo EquipoAsociado { get; set; }
        public Equipo Equipo
        {
            get { return EquipoAsociado; }
            set { EquipoAsociado = value; }
        }

        public string DescripcionProblema { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public Tecnico TecnicoAsignado { get; set; }

        public DateTime FechaHoraRecepcion { get; set; }

        // Propiedad alias para total compatibilidad con reportes y ordenamientos por fecha
        public DateTime FechaCreacion
        {
            get => FechaHoraRecepcion;
            set => FechaHoraRecepcion = value;
        }

        public Stack<string> HistorialEstados { get; set; }
        public List<RepuestoUsado> RepuestosUtilizados { get; set; }
        public double CostoManoObra { get; set; }

        // Propiedad calculada que incluye la fórmula exacta requerida:
        // Costo Total = Costo de Revisión del Equipo + Repuestos + Mano de Obra
        public double Total
        {
            get
            {
                double costoRevisionEquipo = 0;
                if (EquipoAsociado != null)
                {
                    costoRevisionEquipo = EquipoAsociado.CostoRevision;
                }

                double totalRepuestos = 0;
                if (RepuestosUtilizados != null)
                {
                    foreach (var r in RepuestosUtilizados)
                    {
                        totalRepuestos += r.Subtotal;
                    }
                }

                return costoRevisionEquipo + totalRepuestos + CostoManoObra;
            }
        }

        // Propiedades auxiliares para visualización limpia en el DataGridView
        public string NombreClienteFormateado
        {
            get => ClientePropietario != null ? ClientePropietario.NombreCompleto : "Sin cliente";
        }

        public string DescripcionEquipoFormateada
        {
            get => EquipoAsociado != null ? EquipoAsociado.ToString() : "Sin equipo";
        }

        public string NombreTecnicoFormateado
        {
            get => TecnicoAsignado != null ? TecnicoAsignado.NombreCompleto : "Sin asignar";
        }

        // Constructor principal
        public Solicitud(string codigo, Cliente cliente, Equipo equipo, string problema, string prioridad)
        {
            CodigoSolicitud = codigo;
            ClientePropietario = cliente;
            EquipoAsociado = equipo;
            DescripcionProblema = problema;
            Prioridad = string.IsNullOrEmpty(prioridad) ? "Normal" : prioridad;
            Estado = "Recibida";
            TecnicoAsignado = null;
            FechaHoraRecepcion = DateTime.Now;
            HistorialEstados = new Stack<string>();
            RepuestosUtilizados = new List<RepuestoUsado>();

            // Asignación de mano de obra inicial según el equipo
            if (equipo != null)
            {
                string tipo = equipo.GetType().Name;
                if (tipo.Contains("Escritorio"))
                    CostoManoObra = 250.0;
                else if (tipo.Contains("Portatil"))
                    CostoManoObra = 300.0;
                else if (tipo.Contains("Impresora"))
                    CostoManoObra = 200.0;
                else
                    CostoManoObra = 175.0;
            }
            else
            {
                CostoManoObra = 200.0;
            }

            HistorialEstados.Push("Recibida");
        }

        public bool CambiarEstado(string nuevoEstado)
        {
            if (string.IsNullOrEmpty(nuevoEstado)) return false;

            Estado = nuevoEstado;
            HistorialEstados.Push(nuevoEstado);
            return true;
        }

        public bool DeshacerCambioEstado()
        {
            if (HistorialEstados != null && HistorialEstados.Count > 1)
            {
                HistorialEstados.Pop();
                Estado = HistorialEstados.Peek();
                return true;
            }
            return false;
        }
    }
}