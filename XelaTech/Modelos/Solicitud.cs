using System;
using System.Collections.Generic;

namespace XelaTech.Modelos
{
    public class Solicitud
    {
        public string CodigoSolicitud { get; set; }
        public Cliente Cliente { get; set; }
        public Equipo Equipo { get; set; }
        public string DescripcionProblema { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public Tecnico TecnicoAsignado { get; set; }
        public string Diagnostico { get; set; }
        public List<Repuesto> RepuestosUsados { get; set; }
        public double CostoManoObra { get; set; }
        public double CostoRepuestos { get; set; }
        public double Total { get; set; } // <--- ASEGÚRATE DE TENER ESTA PROPIEDAD
        public Stack<string> HistorialEstados { get; set; }

        public Solicitud(string codigoSolicitud, Cliente cliente, Equipo equipo, string descripcionProblema, string prioridad)
        {
            CodigoSolicitud = codigoSolicitud;
            Cliente = cliente;
            Equipo = equipo;
            DescripcionProblema = descripcionProblema;
            FechaRecepcion = DateTime.Now;
            Prioridad = prioridad;
            Estado = "Recibida";
            Diagnostico = "Pendiente de revisión";
            RepuestosUsados = new List<Repuesto>();
            CostoManoObra = equipo.CalcularCostoRevision();
            CostoRepuestos = 0;
            Total = CostoManoObra;
            HistorialEstados = new Stack<string>();
        }
    }
}