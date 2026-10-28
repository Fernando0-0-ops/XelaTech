using System;
using System.Windows.Forms;
using XelaTech.Modelos;
using Microsoft.VisualBasic;

namespace XelaTech
{
    public partial class Módulo_operativo : Form
    {
        public Módulo_operativo()
        {
            InitializeComponent();

            // Enlace directo y seguro para los botones del módulo operativo
            if (button1 != null) button1.Click += (s, e) => { RegistrarNuevaSolicitud(); };
            if (button2 != null) button2.Click += (s, e) => { AtenderSiguienteSolicitud(); };
            if (button3 != null) button3.Click += (s, e) => { Form1 menuPrincipal = new Form1(); menuPrincipal.Show(); this.Close(); };
        }

        private void Módulo_operativo_Load(object sender, EventArgs e)
        {
        }

        // Métodos de compatibilidad vacíos para el diseñador visual
        private void button1_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }

        // ==========================================
        // LÓGICA DE SOLICITUDES Y COLAS
        // ==========================================
        private void RegistrarNuevaSolicitud()
        {
            string codSolicitud = Interaction.InputBox("Código de la solicitud (Ej: SOL-001):", "XelaTech - Solicitudes");
            string codCliente = Interaction.InputBox("Código del cliente (Ej: CLI-001):", "XelaTech - Solicitudes");
            string codEquipo = Interaction.InputBox("Código del equipo (Ej: EQ-001):", "XelaTech - Solicitudes");
            string descripcion = Interaction.InputBox("Descripción del problema:", "XelaTech - Solicitudes");
            string prioridad = Interaction.InputBox("Prioridad (Urgente / Normal):", "XelaTech - Solicitudes");

            if (string.IsNullOrEmpty(codSolicitud) || string.IsNullOrEmpty(codCliente) || string.IsNullOrEmpty(codEquipo) || string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("Los campos principales no pueden estar vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Buscar el cliente en DatosGlobales
            Cliente clienteEncontrado = null;
            foreach (var c in DatosGlobales.ListaClientes)
            {
                if (c.Codigo.Equals(codCliente, StringComparison.OrdinalIgnoreCase))
                {
                    clienteEncontrado = c;
                    break;
                }
            }

            // Buscar el equipo en DatosGlobales
            Equipo equipoEncontrado = null;
            foreach (var eq in DatosGlobales.ListaEquipos)
            {
                if (eq.CodigoInterno.Equals(codEquipo, StringComparison.OrdinalIgnoreCase))
                {
                    equipoEncontrado = eq;
                    break;
                }
            }

            if (clienteEncontrado == null || equipoEncontrado == null)
            {
                MessageBox.Show("No se encontró el cliente o el equipo con los códigos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear la solicitud pasando los parámetros y dejando el técnico en null temporalmente
            Solicitud nuevaSolicitud = new Solicitud(codSolicitud, clienteEncontrado, equipoEncontrado, descripcion, prioridad)
            {
                TecnicoAsignado = null
            };

            // Agregar a la lista global de solicitudes
            DatosGlobales.ListaSolicitudes.Add(nuevaSolicitud);

            MessageBox.Show("¡Solicitud registrada y encolada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AtenderSiguienteSolicitud()
        {
            if (DatosGlobales.ListaSolicitudes.Count == 0)
            {
                MessageBox.Show("No hay solicitudes pendientes en el sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Atender el primer elemento (Cola / Queue simulada con lista)
            Solicitud atendida = DatosGlobales.ListaSolicitudes[0];
            DatosGlobales.ListaSolicitudes.RemoveAt(0);

            string nombreCliente = atendida.Cliente != null ? atendida.Cliente.NombreCompleto : "Cliente";

            MessageBox.Show($"Se ha atendido la solicitud del cliente: {nombreCliente}", "Atención Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}