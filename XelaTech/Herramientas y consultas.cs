using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XelaTech.Modelos;

namespace XelaTech
{
    public partial class Herramientas_y_consultas : Form
    {
        public Herramientas_y_consultas()
        {
            InitializeComponent();

            // Forzar que el formulario no abra maximizado/pantalla completa
            this.WindowState = FormWindowState.Normal;

            // Enlace directo y seguro usando los nombres exactos de tus botones
            if (button1 != null) button1.Click += (s, e) => RegistrarNuevaSolicitud_Click(s, e);
            if (button2 != null) button2.Click += (s, e) => AtenderSiguienteSolicitud_Click(s, e);
            if (button3 != null) button3.Click += (s, e) =>
            {
                GeneradorDatos.CargarDatosIniciales();
                ActualizarTablaYContador();
                MessageBox.Show("¡Datos de prueba generados y cargados exitosamente en las estructuras!", "Generador de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            if (button4 != null) button4.Click += (s, e) =>
            {
                Form1 menu = new Form1();
                menu.Show();
                this.Close();
            };
        }

        private void Herramientas_y_consultas_Load(object sender, EventArgs e)
        {
            ActualizarTablaYContador();
        }

        // Se ejecuta automáticamente cada vez que el usuario regresa o entra a este formulario
        private void Herramientas_y_consultas_Activated(object sender, EventArgs e)
        {
            ActualizarTablaYContador();
        }

        private void ActualizarTablaYContador()
        {
            if (dataGridView1 != null)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DatosGlobales.ListaSolicitudes;
                ResaltarPrioridadesEnTabla();
            }

            int conteoPendientes = DatosGlobales.ListaSolicitudes != null ? DatosGlobales.ListaSolicitudes.Count : 0;
            this.Text = $"Herramientas y Consultas - Solicitudes en cola: {conteoPendientes}";
        }

        private void ResaltarPrioridadesEnTabla()
        {
            if (dataGridView1 == null || dataGridView1.Rows.Count == 0) return;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.DataBoundItem is Solicitud sol)
                {
                    if (sol.Prioridad != null && sol.Prioridad.Equals("Urgente", StringComparison.OrdinalIgnoreCase))
                    {
                        fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230); // Rojo claro
                        fila.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        fila.DefaultCellStyle.BackColor = Color.White;
                        fila.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        // Algoritmo de Ordenamiento Burbuja (BubbleSort) manual implementado con List<T>
        public void OrdenarPorCostoManoObra()
        {
            if (DatosGlobales.ListaSolicitudes == null || DatosGlobales.ListaSolicitudes.Count == 0)
            {
                MessageBox.Show("No hay solicitudes para ordenar. Primero genera datos de prueba.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Solicitud> listaOrdenada = new List<Solicitud>(DatosGlobales.ListaSolicitudes);

            int n = listaOrdenada.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (listaOrdenada[j].CostoManoObra > listaOrdenada[j + 1].CostoManoObra)
                    {
                        Solicitud temp = listaOrdenada[j];
                        listaOrdenada[j] = listaOrdenada[j + 1];
                        listaOrdenada[j + 1] = temp;
                    }
                }
            }

            if (dataGridView1 != null)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listaOrdenada;
            }

            MessageBox.Show(
                "La lista ha sido ordenada de menor a mayor por Costo de Mano de Obra utilizando el Algoritmo Burbuja (BubbleSort).",
                "Ordenamiento Exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void MostrarEstadisticasYReportes()
        {
            if (DatosGlobales.ListaSolicitudes == null || DatosGlobales.ListaSolicitudes.Count == 0)
            {
                MessageBox.Show("No hay solicitudes registradas para generar el reporte. Genere datos de prueba primero.", "Estadísticas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int totalSolicitudes = DatosGlobales.ListaSolicitudes.Count;
            double costoPromedio = DatosGlobales.ListaSolicitudes.Average(s => s.CostoManoObra);
            double costoMaximo = DatosGlobales.ListaSolicitudes.Max(s => s.CostoManoObra);
            double costoMinimo = DatosGlobales.ListaSolicitudes.Min(s => s.CostoManoObra);

            string reporte = $"=== REPORTE ESTADÍSTICO DE XELATECH ===\n\n" +
                             $"• Total de solicitudes: {totalSolicitudes}\n" +
                             $"• Costo promedio de mano de obra: Q{costoPromedio:N2}\n" +
                             $"• Costo máximo de mano de obra: Q{costoMaximo:N2}\n" +
                             $"• Costo mínimo de mano de obra: Q{costoMinimo:N2}";

            MessageBox.Show(reporte, "Módulo de Reportes y Estadísticas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Registrar nueva solicitud (Gestión de Solicitudes)
        private void RegistrarNuevaSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Código de la Solicitud (Ej. SOL-001):", "Registro de Solicitud");
                if (string.IsNullOrWhiteSpace(codigo)) return;

                string codCliente = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Código del Cliente:", "Registro de Solicitud");
                Cliente clienteEncontrado = DatosGlobales.ListaClientes.FirstOrDefault(c => c.Codigo == codCliente);
                if (clienteEncontrado == null)
                {
                    MessageBox.Show("Cliente no encontrado en la base de datos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string codEquipo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Código del Equipo:", "Registro de Solicitud");
                Equipo equipoEncontrado = DatosGlobales.ListaEquipos.FirstOrDefault(eq => eq.CodigoInterno == codEquipo);
                if (equipoEncontrado == null)
                {
                    MessageBox.Show("Equipo no encontrado en la base de datos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string descripcion = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la descripción del problema:", "Registro de Solicitud");
                string prioridad = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la prioridad (Urgente / Normal):", "Registro de Solicitud");

                // Asignación opcional de técnico
                string codTecnico = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Código del Técnico Asignado (opcional):", "Asignación de Técnico");
                Tecnico tecnicoEncontrado = !string.IsNullOrWhiteSpace(codTecnico)
                    ? DatosGlobales.ListaTecnicos.FirstOrDefault(t => t.Codigo == codTecnico)
                    : null;

                // Instancia de la solicitud
                Solicitud nuevaSolicitud = new Solicitud(codigo, clienteEncontrado, equipoEncontrado, descripcion, prioridad);

                if (tecnicoEncontrado != null)
                    nuevaSolicitud.TecnicoAsignado = tecnicoEncontrado;

                // Uso correcto de .Push() ya que HistorialEstados es un Stack<string>
                if (nuevaSolicitud.HistorialEstados != null)
                {
                    nuevaSolicitud.HistorialEstados.Push($"[{DateTime.Now:dd/MM/yyyy HH:mm}] Estado: Recibido / Ingresado");
                }

                DatosGlobales.ListaSolicitudes.Add(nuevaSolicitud);

                MessageBox.Show("Solicitud registrada, técnico asignado e historial iniciado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTablaYContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la solicitud: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Atender solicitud (Atención de Colas y Prioridades)
        private void AtenderSiguienteSolicitud_Click(object sender, EventArgs e)
        {
            if (DatosGlobales.ListaSolicitudes == null || DatosGlobales.ListaSolicitudes.Count == 0)
            {
                MessageBox.Show("No hay solicitudes pendientes en la cola.", "Cola Vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Solicitud solicitudAtender = DatosGlobales.ListaSolicitudes[0];

            string nombreCliente = solicitudAtender.Cliente != null ? solicitudAtender.Cliente.NombreCompleto : "Desconocido";
            string modeloEquipo = solicitudAtender.Equipo != null ? solicitudAtender.Equipo.Modelo : "N/A";

            DialogResult confirmacion = MessageBox.Show(
                $"¿Desea proceder con la atención de la siguiente solicitud?\n\n" +
                $"• Código: {solicitudAtender.CodigoSolicitud}\n" +
                $"• Cliente: {nombreCliente}\n" +
                $"• Equipo: {modeloEquipo}\n" +
                $"• Prioridad: {solicitudAtender.Prioridad}",
                "Confirmación de Atención",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                DatosGlobales.ListaSolicitudes.RemoveAt(0);
                MessageBox.Show($"La solicitud {solicitudAtender.CodigoSolicitud} de {nombreCliente} ha sido atendida exitosamente.", "Atención Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTablaYContador();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mensajeResumen = GeneradorDatos.GenerarDatosPrueba();
            MessageBox.Show(mensajeResumen, "Módulo de Datos de Prueba - XelaTech", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Módulo_de_Reportes_y_Estadísticas formReportes = new Módulo_de_Reportes_y_Estadísticas();
            formReportes.Show();
            this.Close();
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            // Verificamos que haya una fila seleccionada en el dataGridView1
            if (dataGridView1.CurrentRow != null)
            {
                Solicitud solicitudSeleccionada = dataGridView1.CurrentRow.DataBoundItem as Solicitud;

                if (solicitudSeleccionada != null)
                {
                    bool exito = solicitudSeleccionada.DeshacerCambioEstado();

                    if (exito)
                    {
                        MessageBox.Show($"Cambio deshecho con éxito. Estado actual: {solicitudSeleccionada.Estado}", "Deshacer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refrescamos la tabla para que se vea el cambio reflejado al instante
                        dataGridView1.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("No es posible deshacer más estados para esta solicitud.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una solicitud de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}