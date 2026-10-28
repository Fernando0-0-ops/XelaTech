using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XelaTech.Modelos;

namespace XelaTech
{
    public partial class Módulo_de_Reportes_y_Estadísticas : Form
    {
        public Módulo_de_Reportes_y_Estadísticas()
        {
            InitializeComponent();
        }

        private void Módulo_de_Reportes_y_Estadísticas_Load(object sender, EventArgs e)
        {
            CargarEstadisticasYReportes();

            // Enlace dinámico por si el botón de volver o salir tiene otro nombre en tu diseño
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    if (btn.Text.Contains("Volver") || btn.Text.Contains("Regresar"))
                    {
                        btn.Click += (s, ev) => RegresarHerramientas();
                    }
                }
            }
        }

        private void CargarEstadisticasYReportes()
        {
            // Uso estricto de .Count en lugar de .Length para colecciones List<T>
            int totalClientes = DatosGlobales.ListaClientes.Count;
            int totalTecnicos = DatosGlobales.ListaTecnicos.Count;
            int totalEquipos = DatosGlobales.ListaEquipos.Count;
            int totalSolicitudes = DatosGlobales.ListaSolicitudes.Count;
            int totalRepuestos = DatosGlobales.ListaRepuestos.Count;

            string reporte = "=== REPORTE GENERAL Y ESTADÍSTICAS XELATECH ===\n\n" +
                             $"• Total de Clientes: {totalClientes}\n" +
                             $"• Total de Técnicos: {totalTecnicos}\n" +
                             $"• Total de Equipos: {totalEquipos}\n" +
                             $"• Total de Solicitudes: {totalSolicitudes}\n" +
                             $"• Total de Repuestos: {totalRepuestos}\n\n";

            // Validación de calificaciones usando .Count
            if (DatosGlobales.CalificacionesAtencion != null && DatosGlobales.CalificacionesAtencion.Count > 0)
            {
                double suma = 0;
                foreach (var cal in DatosGlobales.CalificacionesAtencion)
                {
                    suma += cal;
                }
                double promedio = suma / DatosGlobales.CalificacionesAtencion.Count;
                reporte += $"• Promedio de Calificación de Atención: {promedio:F2} estrellas\n";
            }
            else
            {
                reporte += "• Promedio de Calificación: Sin calificaciones registradas.\n";
            }

            MessageBox.Show(reporte, "Módulo de Reportes y Estadísticas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RegresarHerramientas()
        {
            Herramientas_y_consultas herramientasForm = new Herramientas_y_consultas();
            herramientasForm.Show();
            this.Close();
        }
    }
}