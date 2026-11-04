using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
            if (button1 != null) button1.Click += (s, e) => ActualizarTablaSolicitudes();
            if (button2 != null) button2.Click += button2_Click_1;
            if (button3 != null) button3.Click += button3_Click;

            // Enlazamos el botón 8 para registrar una nueva solicitud
            if (button8 != null) button8.Click += (s, e) => RegistrarNuevaSolicitud();

            // Conectamos el evento de doble clic para avanzar el ciclo de vida de forma interactiva
            if (dataGridView1 != null)
            {
                dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            }
        }

        private void Módulo_operativo_Load(object sender, EventArgs e)
        {
            // Sincronizar colas vacías si ya existen solicitudes cargadas en el sistema
            SincronizarColasSiEsNecesario();

            ActualizarTablaSolicitudes();
            ConfigurarEstiloTabla();
        }

        // Se ejecuta automáticamente cada vez que el usuario regresa o entra a este formulario
        private void Módulo_operativo_Activated(object sender, EventArgs e)
        {
            ConfigurarEstiloTabla();
        }

        private void SincronizarColasSiEsNecesario()
        {
            if (DatosGlobales.ColaUrgentes.Count == 0 && DatosGlobales.ColaNormales.Count == 0 && DatosGlobales.ListaSolicitudes != null)
            {
                foreach (var s in DatosGlobales.ListaSolicitudes)
                {
                    if (s.Estado != "Entregada" && s.Estado != "Cancelada")
                    {
                        if (s.Prioridad != null && s.Prioridad.Equals("Urgente", StringComparison.OrdinalIgnoreCase))
                        {
                            DatosGlobales.ColaUrgentes.Enqueue(s);
                        }
                        else
                        {
                            DatosGlobales.ColaNormales.Enqueue(s);
                        }
                    }
                }
            }
        }

        private void ConfigurarEstiloTabla()
        {
            if (dataGridView1 != null)
            {
                // Configuración visual para mantener el texto negro, nítido y legible
                dataGridView1.ForeColor = Color.Black;
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
                dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

                // Ajuste de columnas proporcional para evitar amontonamientos
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void ActualizarTablaSolicitudes()
        {
            int firstRowIndex = -1;
            try
            {
                if (dataGridView1.FirstDisplayedScrollingRowIndex >= 0)
                {
                    firstRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex;
                }
            }
            catch { }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DatosGlobales.ListaSolicitudes;
            ConfigurarEstiloTabla();

            try
            {
                if (firstRowIndex >= 0 && firstRowIndex < dataGridView1.Rows.Count)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = firstRowIndex;
                }
            }
            catch { }
        }

        private string PedirDato(string mensaje)
        {
            return Interaction.InputBox(mensaje, "XELATECH SOPORTE - OPERACIONES").Trim();
        }

        // =========================================================================
        // MÉTODO DE REGISTRO DE SOLICITUD CON VALIDACIÓN Y ENCOLAMIENTO (PUNTO 5)
        // =========================================================================
        public void RegistrarNuevaSolicitud()
        {
            string codigoSol = PedirDato("Ingrese el Código de la Solicitud (Ej: SOL-001):");
            string codigoCliente = PedirDato("Ingrese el Código del Cliente propietario:");
            string codigoEquipo = PedirDato("Ingrese el Código Interno del Equipo:");
            string problema = PedirDato("Descripción del problema reportado:");
            string prioridad = PedirDato("Prioridad de la solicitud (Normal / Urgente):");

            if (string.IsNullOrEmpty(codigoSol) || string.IsNullOrEmpty(codigoCliente) || string.IsNullOrEmpty(codigoEquipo))
            {
                MessageBox.Show("Los códigos de solicitud, cliente y equipo son obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool codigoRepetido = false;
            foreach (var s in DatosGlobales.ListaSolicitudes)
            {
                if (s.CodigoSolicitud.Equals(codigoSol, StringComparison.OrdinalIgnoreCase))
                {
                    codigoRepetido = true;
                    break;
                }
            }

            if (codigoRepetido)
            {
                MessageBox.Show("Ya existe una solicitud registrada con ese código.", "Código Repetido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente clienteEncontrado = null;
            foreach (var c in DatosGlobales.ListaClientes)
            {
                if (c.Codigo.Equals(codigoCliente, StringComparison.OrdinalIgnoreCase))
                {
                    clienteEncontrado = c;
                    break;
                }
            }
            if (clienteEncontrado == null)
            {
                MessageBox.Show("No se encontró ningún cliente con el código especificado.", "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Equipo equipoEncontrado = null;
            foreach (var eq in DatosGlobales.ListaEquipos)
            {
                if (eq.CodigoInterno.Equals(codigoEquipo, StringComparison.OrdinalIgnoreCase))
                {
                    equipoEncontrado = eq;
                    break;
                }
            }
            if (equipoEncontrado == null)
            {
                MessageBox.Show("No se encontró ningún equipo con el código interno especificado.", "Equipo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool equipoTieneProcesoActivo = false;
            foreach (var s in DatosGlobales.ListaSolicitudes)
            {
                if (s.EquipoAsociado != null &&
                    s.EquipoAsociado.CodigoInterno.Equals(codigoEquipo, StringComparison.OrdinalIgnoreCase) &&
                    s.Estado != "Entregada" &&
                    s.Estado != "Cancelada")
                {
                    equipoTieneProcesoActivo = true;
                    break;
                }
            }

            if (equipoTieneProcesoActivo)
            {
                MessageBox.Show($"El equipo con código '{codigoEquipo}' ya cuenta con una solicitud activa en el sistema.\nNo se puede registrar otra hasta que la actual finalice o se cancele.",
                        "Solicitud No Permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string prioridadFinal = string.IsNullOrEmpty(prioridad) ? "Normal" : prioridad;
            Solicitud nuevaSolicitud = new Solicitud(codigoSol, clienteEncontrado, equipoEncontrado, problema, prioridadFinal);

            // 1. Agregar a la lista global
            DatosGlobales.ListaSolicitudes.Add(nuevaSolicitud);

            // 2. Encolar obligatoriamente por prioridad (Punto 5)
            if (prioridadFinal.Equals("Urgente", StringComparison.OrdinalIgnoreCase))
            {
                DatosGlobales.ColaUrgentes.Enqueue(nuevaSolicitud);
            }
            else
            {
                DatosGlobales.ColaNormales.Enqueue(nuevaSolicitud);
            }

            ActualizarTablaSolicitudes();
            MessageBox.Show("¡Solicitud registrada exitosamente y encolada por prioridad!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =========================================================================
        // REGLAS DE NEGOCIO: ASIGNACIÓN CON VALIDACIÓN Y MATRIZ DE CARGA (PUNTO 7)
        // =========================================================================
        public void AsignarTecnicoYProcesar(Solicitud solicitud, Tecnico tecnicoAElegir)
        {
            if (solicitud == null || tecnicoAElegir == null) return;

            if (tecnicoAElegir.TrabajosActivos >= tecnicoAElegir.LimiteTrabajos)
            {
                MessageBox.Show($"El técnico {tecnicoAElegir.NombreCompleto} ha alcanzado su límite máximo de trabajos activos.",
                        "Límite Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (solicitud.EquipoAsociado != null)
            {
                string tipoEquipo = solicitud.EquipoAsociado.GetType().Name;
                string especialidadTecnico = tecnicoAElegir.Especialidad ?? "";

                bool especialidadCoincide = false;
                if (especialidadTecnico.Equals("Todos", StringComparison.OrdinalIgnoreCase) ||
                    especialidadTecnico.Equals("General", StringComparison.OrdinalIgnoreCase))
                {
                    especialidadCoincide = true;
                }
                else if (tipoEquipo.Contains("Portatil") && especialidadTecnico.IndexOf("Portátil", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    especialidadCoincide = true;
                }
                else if (tipoEquipo.Contains("Escritorio") && especialidadTecnico.IndexOf("Escritorio", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    especialidadCoincide = true;
                }
                else if (tipoEquipo.Contains("Impresora") && especialidadTecnico.IndexOf("Impresora", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    especialidadCoincide = true;
                }
                else if (especialidadTecnico.Equals(tipoEquipo, StringComparison.OrdinalIgnoreCase))
                {
                    especialidadCoincide = true;
                }

                if (!especialidadCoincide)
                {
                    MessageBox.Show($"La especialidad del técnico ({tecnicoAElegir.Especialidad}) no es compatible con el tipo de equipo ({tipoEquipo}).",
                                    "Especialidad Incompatible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            solicitud.TecnicoAsignado = tecnicoAElegir;
            tecnicoAElegir.TrabajosActivos++;

            int indiceTecnico = -1;
            for (int i = 0; i < DatosGlobales.ListaTecnicos.Count; i++)
            {
                if (DatosGlobales.ListaTecnicos[i].Codigo.Equals(tecnicoAElegir.Codigo, StringComparison.OrdinalIgnoreCase))
                {
                    indiceTecnico = i;
                    break;
                }
            }

            if (indiceTecnico >= 0 && indiceTecnico < 10)
            {
                int colDia = 0;
                DayOfWeek diaActual = DateTime.Now.DayOfWeek;
                if (diaActual >= DayOfWeek.Monday && diaActual <= DayOfWeek.Friday)
                {
                    colDia = (int)diaActual - 1;
                }

                DatosGlobales.RegistrarAsignacionMatriz(indiceTecnico, colDia);
            }

            bool exito = solicitud.CambiarEstado("Asignada");
            if (!exito)
            {
                solicitud.CambiarEstado("En espera");
            }

            dataGridView1.Refresh();
            MessageBox.Show($"¡Solicitud {solicitud.CodigoSolicitud} asignada correctamente al técnico {tecnicoAElegir.NombreCompleto}!",
                    "Asignación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UtilizarRepuestoEnReparacion(Solicitud solicitud)
        {
            if (solicitud == null) return;

            if (!solicitud.Estado.Equals("En reparación", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La solicitud debe estar en estado 'En reparación' para asignarle repuestos.", "Flujo No Permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codigoRepuesto = PedirDato("Ingrese el código del repuesto a utilizar (Ej: REP-01):");
            if (string.IsNullOrEmpty(codigoRepuesto)) return;

            Repuesto repuestoEncontrado = null;
            foreach (var r in DatosGlobales.ListaRepuestos)
            {
                if (r.Codigo.Equals(codigoRepuesto, StringComparison.OrdinalIgnoreCase))
                {
                    repuestoEncontrado = r;
                    break;
                }
            }

            if (repuestoEncontrado == null)
            {
                MessageBox.Show("No se encontró ningún repuesto con ese código.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strCantidad = PedirDato($"Repuesto: {repuestoEncontrado.Nombre}\nStock disponible: {repuestoEncontrado.CantidadDisponible}\nPrecio Unitario: Q{repuestoEncontrado.PrecioVenta:F2}\n\nIngrese la cantidad a utilizar:");
            int cantidadAUsar;

            if (!int.TryParse(strCantidad, out cantidadAUsar) || cantidadAUsar <= 0)
            {
                MessageBox.Show("Por favor ingrese una cantidad numérica válida mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool descuentoExitoso = repuestoEncontrado.DescontarStock(cantidadAUsar);

            if (descuentoExitoso)
            {
                solicitud.RepuestosUtilizados.Add(new RepuestoUsado(repuestoEncontrado, cantidadAUsar));

                string alertaStock = "";
                if (repuestoEncontrado.EstaAgotado())
                {
                    alertaStock = "\n\n⚠️ ¡ADVERTENCIA: El repuesto ha quedado completamente AGOTADO!";
                }
                else if (repuestoEncontrado.TienePocaExistencia())
                {
                    alertaStock = "\n\n⚠️ ¡ADVERTENCIA: El repuesto ha entrado en NIVEL CRÍTICO de stock!";
                }

                double subtotalAplicado = cantidadAUsar * repuestoEncontrado.PrecioVenta;
                MessageBox.Show($"¡Repuesto aplicado con éxito!\nSe descontaron {cantidadAUsar} unidad(es) de '{repuestoEncontrado.Nombre}'.\nSubtotal aplicado: Q{subtotalAplicado:F2}{alertaStock}",
                        "Repuesto Utilizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show($"Stock insuficiente. No se pueden descontar {cantidadAUsar} unidades. Stock disponible actual: {repuestoEncontrado.CantidadDisponible}.",
                        "Inventario Superado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Solicitud solicitudSeleccionada = dataGridView1.Rows[e.RowIndex].DataBoundItem as Solicitud;

                if (solicitudSeleccionada != null)
                {
                    string estadoActual = solicitudSeleccionada.Estado;
                    string siguienteEstado = "";

                    if (estadoActual == "Recibida") siguienteEstado = "Asignada";
                    else if (estadoActual == "En espera") siguienteEstado = "Asignada";
                    else if (estadoActual == "Asignada") siguienteEstado = "En diagnóstico";
                    else if (estadoActual == "En diagnóstico") siguienteEstado = "En reparación";
                    else if (estadoActual == "En reparación")
                    {
                        DialogResult usarRep = MessageBox.Show("¿Desea utilizar repuestos en esta reparación?", "Flujo de Reparación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (usarRep == DialogResult.Yes)
                        {
                            UtilizarRepuestoEnReparacion(solicitudSeleccionada);
                            return;
                        }
                        siguienteEstado = "Lista para entregar";
                    }
                    else if (estadoActual == "Lista para entregar") siguienteEstado = "Entregada";
                    else
                    {
                        MessageBox.Show("La solicitud ya se encuentra finalizada o cancelada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (siguienteEstado == "Asignada" && solicitudSeleccionada.TecnicoAsignado == null && DatosGlobales.ListaTecnicos.Count > 0)
                    {
                        string tipoEquipoActual = solicitudSeleccionada.EquipoAsociado != null ? solicitudSeleccionada.EquipoAsociado.GetType().Name : "";

                        Tecnico techLibre = null;
                        foreach (var t in DatosGlobales.ListaTecnicos)
                        {
                            bool especialidadOk = string.IsNullOrEmpty(t.Especialidad) ||
                                            t.Especialidad.Equals("Todos", StringComparison.OrdinalIgnoreCase) ||
                                            (tipoEquipoActual.Contains("Portatil") && t.Especialidad.IndexOf("Portátil", StringComparison.OrdinalIgnoreCase) >= 0) ||
                                            (tipoEquipoActual.Contains("Escritorio") && t.Especialidad.IndexOf("Escritorio", StringComparison.OrdinalIgnoreCase) >= 0) ||
                                            (tipoEquipoActual.Contains("Impresora") && t.Especialidad.IndexOf("Impresora", StringComparison.OrdinalIgnoreCase) >= 0);

                            if (t.TrabajosActivos < t.LimiteTrabajos && especialidadOk)
                            {
                                techLibre = t;
                                break;
                            }
                        }

                        if (techLibre != null)
                        {
                            AsignarTecnicoYProcesar(solicitudSeleccionada, techLibre);
                            return;
                        }
                    }

                    bool cambioExitoso = solicitudSeleccionada.CambiarEstado(siguienteEstado);

                    if (cambioExitoso)
                    {
                        if (siguienteEstado == "Entregada" && solicitudSeleccionada.TecnicoAsignado != null)
                        {
                            if (solicitudSeleccionada.TecnicoAsignado.TrabajosActivos > 0)
                            {
                                solicitudSeleccionada.TecnicoAsignado.TrabajosActivos--;
                            }
                            solicitudSeleccionada.TecnicoAsignado.ServiciosFinalizados++;
                        }

                        MessageBox.Show($"Estado actualizado exitosamente a: {siguienteEstado}", "Ciclo de Taller", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.Refresh();
                    }
                    else
                    {
                        MessageBox.Show($"No se pudo realizar la transición de '{estadoActual}' a '{siguienteEstado}'.", "Restricción de Estado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Solicitud solicitudAtendida = null;
            string tipoColaAtendida = "";

            if (DatosGlobales.ColaUrgentes != null && DatosGlobales.ColaUrgentes.Count > 0)
            {
                solicitudAtendida = DatosGlobales.ColaUrgentes.Dequeue();
                tipoColaAtendida = "Urgente";
            }
            else if (DatosGlobales.ColaNormales != null && DatosGlobales.ColaNormales.Count > 0)
            {
                solicitudAtendida = DatosGlobales.ColaNormales.Dequeue();
                tipoColaAtendida = "Normal";
            }
            else
            {
                MessageBox.Show("No hay solicitudes pendientes en las colas de atención.", "Colas Vacías", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new List<Solicitud> { solicitudAtendida };
            ConfigurarEstiloTabla();

            MessageBox.Show($"Atendiendo siguiente solicitud de la cola [{tipoColaAtendida}]:\nCódigo: {solicitudAtendida.CodigoSolicitud}\nProblema: {solicitudAtendida.DescripcionProblema}",
                            "Atención de Cola", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Búsqueda Clientes
        private void button4_Click(object sender, EventArgs e)
        {
            string nombreParcial = txtCriterio.Text.Trim();
            if (string.IsNullOrEmpty(nombreParcial)) { MessageBox.Show("Ingresa un nombre de cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            List<Cliente> resultados = new List<Cliente>();
            foreach (var c in DatosGlobales.ListaClientes)
            {
                if (c.NombreCompleto != null && c.NombreCompleto.IndexOf(nombreParcial, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    resultados.Add(c);
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultados;
            ConfigurarEstiloTabla();
            if (resultados.Count == 0) MessageBox.Show("No se encontraron clientes.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Búsqueda Equipos por Marca
        private void button5_Click(object sender, EventArgs e)
        {
            string marcaBuscada = txtCriterio.Text.Trim();
            if (string.IsNullOrEmpty(marcaBuscada)) { MessageBox.Show("Ingresa una marca de equipo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            List<Equipo> resultados = new List<Equipo>();
            foreach (var eq in DatosGlobales.ListaEquipos)
            {
                if (eq.Marca != null && eq.Marca.IndexOf(marcaBuscada, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    resultados.Add(eq);
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultados;
            ConfigurarEstiloTabla();
            if (resultados.Count == 0) MessageBox.Show("No se encontraron equipos.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Búsqueda por Estado
        private void button6_Click(object sender, EventArgs e)
        {
            string estadoBuscado = txtCriterio.Text.Trim();
            if (string.IsNullOrEmpty(estadoBuscado)) { MessageBox.Show("Ingresa un estado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            List<Solicitud> solicitudesFiltradas = new List<Solicitud>();
            foreach (var s in DatosGlobales.ListaSolicitudes)
            {
                if (s.Estado != null && s.Estado.IndexOf(estadoBuscado, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    solicitudesFiltradas.Add(s);
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = solicitudesFiltradas;
            ConfigurarEstiloTabla();
            if (solicitudesFiltradas.Count == 0) MessageBox.Show("No se encontraron solicitudes.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Búsqueda Binaria Exacta
        private void button7_Click(object sender, EventArgs e)
        {
            string codigoBuscado = txtCriterio.Text.Trim();
            if (string.IsNullOrEmpty(codigoBuscado)) { MessageBox.Show("Ingresa un código exacto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            List<Solicitud> listaOrdenada = new List<Solicitud>(DatosGlobales.ListaSolicitudes);

            int n = listaOrdenada.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(listaOrdenada[j].CodigoSolicitud, listaOrdenada[j + 1].CodigoSolicitud, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        Solicitud temp = listaOrdenada[j];
                        listaOrdenada[j] = listaOrdenada[j + 1];
                        listaOrdenada[j + 1] = temp;
                    }
                }
            }

            Solicitud encontrada = null;
            int inicio = 0, fin = listaOrdenada.Count - 1;

            while (inicio <= fin)
            {
                int medio = inicio + (fin - inicio) / 2;
                int comparacion = string.Compare(listaOrdenada[medio].CodigoSolicitud, codigoBuscado, StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0) { encontrada = listaOrdenada[medio]; break; }
                else if (comparacion < 0) { inicio = medio + 1; }
                else { fin = medio - 1; }
            }

            dataGridView1.DataSource = null;
            if (encontrada != null)
            {
                dataGridView1.DataSource = new List<Solicitud> { encontrada };
                ConfigurarEstiloTabla();
                MessageBox.Show("¡Solicitud localizada mediante Búsqueda Binaria manual!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView1.DataSource = new List<Solicitud>();
                ConfigurarEstiloTabla();
                MessageBox.Show("No se encontró la solicitud.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCriterio_TextChanged(object sender, EventArgs e)
        {
            string estadoBuscado = txtCriterio.Text.Trim();
            if (string.IsNullOrEmpty(estadoBuscado))
            {
                ActualizarTablaSolicitudes();
                return;
            }

            List<Solicitud> solicitudesFiltradas = new List<Solicitud>();
            foreach (var s in DatosGlobales.ListaSolicitudes)
            {
                if (s.Estado != null && s.Estado.IndexOf(estadoBuscado, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    solicitudesFiltradas.Add(s);
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = solicitudesFiltradas;
            ConfigurarEstiloTabla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 menuPrincipal = new Form1();
            menuPrincipal.Show();
            this.Close();
        }
    }
}