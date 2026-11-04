using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
            ConfigurarEstiloTabla();
            button1_Click(sender, e);
        }

        // Se ejecuta automáticamente cada vez que el usuario regresa o entra a este formulario
        private void Módulo_de_Reportes_y_Estadísticas_Activated(object sender, EventArgs e)
        {
            ConfigurarEstiloTabla();
        }

        private void ConfigurarEstiloTabla()
        {
            if (dataGridView1 != null)
            {
                // 1. Estilos visuales de color
                dataGridView1.ForeColor = Color.Black;
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
                dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

                // 2. Ajuste automático por celda para evitar que se amontonen las columnas
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // 3. Ajusta la altura de las filas para un acabado más limpio
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        // =========================================================================
        // BOTÓN 1: REPORTE FINANCIERO Y RESUMEN GENERAL (Incluye Estado y Prioridad)
        // =========================================================================
        private void button1_Click(object sender, EventArgs e)
        {
            var todasLasSolicitudes = DatosGlobales.ListaSolicitudes.ToList() ?? new List<Solicitud>();

            decimal ingresosTotales = 0;
            foreach (var s in todasLasSolicitudes)
            {
                ingresosTotales += Convert.ToDecimal(s.Total);
            }

            int totalUrgentes = todasLasSolicitudes.Count(s => s.Prioridad != null && s.Prioridad.Equals("Urgente", StringComparison.OrdinalIgnoreCase));
            int totalNormales = todasLasSolicitudes.Count(s => s.Prioridad != null && s.Prioridad.Equals("Normal", StringComparison.OrdinalIgnoreCase));
            int totalRecibidas = todasLasSolicitudes.Count(s => s.Estado == "Recibida");
            int totalEnProceso = todasLasSolicitudes.Count(s => s.Estado == "En reparación" || s.Estado == "En diagnóstico" || s.Estado == "Asignada");
            int totalFinalizadas = todasLasSolicitudes.Count(s => s.Estado == "Entregada" || s.Estado == "Lista para entregar");

            var reporteFinanciero = new List<object>
            {
                new { Categoria = "GENERAL", Indicador = "Total de Solicitudes Registradas", Detalle = todasLasSolicitudes.Count.ToString() },
                new { Categoria = "GENERAL", Indicador = "Ingresos Totales (Mano de Obra + Repuestos)", Detalle = $"Q{ingresosTotales:N2}" },
                new { Categoria = "POR PRIORIDAD", Indicador = "Solicitudes con Prioridad 'Urgente'", Detalle = totalUrgentes.ToString() },
                new { Categoria = "POR PRIORIDAD", Indicador = "Solicitudes con Prioridad 'Normal'", Detalle = totalNormales.ToString() },
                new { Categoria = "POR ESTADO", Indicador = "Solicitudes en Estado 'Recibida'", Detalle = totalRecibidas.ToString() },
                new { Categoria = "POR ESTADO", Indicador = "Solicitudes Activas / En Proceso", Detalle = totalEnProceso.ToString() },
                new { Categoria = "POR ESTADO", Indicador = "Solicitudes Listas o Entregadas", Detalle = totalFinalizadas.ToString() }
            };

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reporteFinanciero;
            ConfigurarEstiloTabla();
        }

        // =========================================================================
        // BOTÓN 2: REPORTE DE RENDIMIENTO Y CARGA DE TÉCNICOS
        // =========================================================================
        private void button2_Click(object sender, EventArgs e)
        {
            var tecnicos = DatosGlobales.ListaTecnicos.ToList() ?? new List<Tecnico>();

            var reporteTecnicos = tecnicos.Select(tecnico => new
            {
                Codigo = tecnico.CodigoTecnico,
                Nombre = tecnico.NombreCompleto,
                Especialidad = tecnico.Especialidad,
                TrabajosActivos = tecnico.TrabajosActivos,
                ServiciosFinalizados = tecnico.ServiciosFinalizados,
                LimiteMaximo = tecnico.LimiteTrabajos
            }).OrderByDescending(t => t.ServiciosFinalizados).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reporteTecnicos;
            ConfigurarEstiloTabla();
        }

        // =========================================================================
        // BOTÓN 3: MATRIZ NUMÉRICA SEMANAL DE CARGA DE TÉCNICOS (PUNTO 7)
        // =========================================================================
        private void button3_Click(object sender, EventArgs e)
        {
            DataTable tablaMatriz = new DataTable();
            tablaMatriz.Columns.Add("Código");
            tablaMatriz.Columns.Add("Técnico");

            foreach (var dia in DatosGlobales.DiasSemana)
            {
                tablaMatriz.Columns.Add(dia);
            }

            tablaMatriz.Columns.Add("Total Semanal");

            var tecnicos = DatosGlobales.ListaTecnicos;
            if (tecnicos != null)
            {
                for (int i = 0; i < tecnicos.Count && i < 10; i++)
                {
                    DataRow fila = tablaMatriz.NewRow();
                    fila["Código"] = tecnicos[i].CodigoTecnico;
                    fila["Técnico"] = tecnicos[i].NombreCompleto;

                    int sumaFila = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        int valorCarga = DatosGlobales.MatrizCargaTecnicos[i, j];
                        fila[DatosGlobales.DiasSemana[j]] = valorCarga;
                        sumaFila += valorCarga;
                    }
                    fila["Total Semanal"] = sumaFila;

                    tablaMatriz.Rows.Add(fila);
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tablaMatriz;
            ConfigurarEstiloTabla();

            string tecnicoTop = DatosGlobales.ObtenerTecnicoConMayorCarga();
            MessageBox.Show(this, $"📊 MATRIZ SEMANAL DE CARGA DE TÉCNICOS (INT[,])\n\n🏆 Técnico con mayor carga semanal:\n{tecnicoTop}",
                            "Reporte de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =========================================================================
        // BOTÓN 4: REPORTE DE INVENTARIO CRÍTICO (Usando Reflexión Segura)
        // =========================================================================
        private void button4_Click(object sender, EventArgs e)
        {
            var repuestos = DatosGlobales.ListaRepuestos;
            var criticos = new List<object>();

            if (repuestos != null)
            {
                foreach (var r in repuestos)
                {
                    var tipo = r.GetType();
                    var propStock = tipo.GetProperty("Stock") ?? tipo.GetProperty("Existencia") ?? tipo.GetProperty("Cantidad") ?? tipo.GetProperty("CantidadDisponible");
                    var propMin = tipo.GetProperty("StockMinimo") ?? tipo.GetProperty("Minimo") ?? tipo.GetProperty("ExistenciaMinima");
                    var propCodigo = tipo.GetProperty("CodigoRepuesto") ?? tipo.GetProperty("Codigo") ?? tipo.GetProperty("Id");
                    var propNombre = tipo.GetProperty("Nombre") ?? tipo.GetProperty("NombreRepuesto") ?? tipo.GetProperty("Descripcion");

                    int stockVal = propStock != null ? Convert.ToInt32(propStock.GetValue(r) ?? 0) : 0;
                    int minVal = propMin != null ? Convert.ToInt32(propMin.GetValue(r) ?? 0) : 0;
                    string codigoVal = propCodigo != null ? propCodigo.GetValue(r)?.ToString() : "N/A";
                    string nombreVal = propNombre != null ? propNombre.GetValue(r)?.ToString() : "Repuesto";

                    if (stockVal <= minVal)
                    {
                        criticos.Add(new
                        {
                            Codigo = codigoVal,
                            Repuesto = nombreVal,
                            StockActual = stockVal,
                            StockMinimoRequerido = minVal,
                            EstadoInventario = stockVal == 0 ? "¡AGOTADO!" : "¡STOCK CRÍTICO!"
                        });
                    }
                }

                if (criticos.Count == 0)
                {
                    foreach (var r in repuestos)
                    {
                        var tipo = r.GetType();
                        var propStock = tipo.GetProperty("Stock") ?? tipo.GetProperty("Existencia") ?? tipo.GetProperty("Cantidad") ?? tipo.GetProperty("CantidadDisponible");
                        var propMin = tipo.GetProperty("StockMinimo") ?? tipo.GetProperty("Minimo") ?? tipo.GetProperty("ExistenciaMinima");
                        var propCodigo = tipo.GetProperty("CodigoRepuesto") ?? tipo.GetProperty("Codigo") ?? tipo.GetProperty("Id");
                        var propNombre = tipo.GetProperty("Nombre") ?? tipo.GetProperty("NombreRepuesto") ?? tipo.GetProperty("Descripcion");

                        int stockVal = propStock != null ? Convert.ToInt32(propStock.GetValue(r) ?? 0) : 0;
                        int minVal = propMin != null ? Convert.ToInt32(propMin.GetValue(r) ?? 0) : 0;
                        string codigoVal = propCodigo != null ? propCodigo.GetValue(r)?.ToString() : "N/A";
                        string nombreVal = propNombre != null ? propNombre.GetValue(r)?.ToString() : "Repuesto";

                        criticos.Add(new
                        {
                            Codigo = codigoVal,
                            Repuesto = nombreVal,
                            StockActual = stockVal,
                            StockMinimoRequerido = minVal,
                            EstadoInventario = "Óptimo"
                        });
                    }
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = criticos;
            ConfigurarEstiloTabla();
        }

        // =========================================================================
        // BOTÓN 5: HISTORIAL DE CAMBIOS DE ESTADO POR SOLICITUD
        // =========================================================================
        private void button5_Click(object sender, EventArgs e)
        {
            var solicitudes = DatosGlobales.ListaSolicitudes.ToList() ?? new List<Solicitud>();

            var historialPlano = solicitudes.Select(s => new
            {
                CodigoSolicitud = s.CodigoSolicitud,
                Cliente = s.ClientePropietario != null ? s.ClientePropietario.NombreCompleto : "Sin cliente",
                Prioridad = s.Prioridad,
                EstadoActual = s.Estado,
                HistorialPila = s.HistorialEstados != null && s.HistorialEstados.Count > 0
                    ? string.Join(" ➔ ", s.HistorialEstados.Reverse())
                    : "Recibida (Inicial)"
            }).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = historialPlano;
            ConfigurarEstiloTabla();
        }

        // =========================================================================
        // REPORTES ADICIONALES (Equipos por Tipo y Solicitudes por Fecha)
        // =========================================================================
        public void ReporteEquiposPorTipo()
        {
            var equipos = DatosGlobales.ListaEquipos.ToList() ?? new List<Equipo>();

            var reporteEquipos = equipos.Select(eq => new
            {
                Codigo = eq.CodigoInterno,
                TipoEquipo = eq.GetType().Name,
                Marca = eq.Marca,
                Modelo = eq.Modelo,
                Propietario = eq.Propietario != null ? eq.Propietario.NombreCompleto : "Sin asignar"
            }).OrderBy(e => e.TipoEquipo).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reporteEquipos;
            ConfigurarEstiloTabla();
            MessageBox.Show(this, "Reporte generado:\nEquipos atendidos agrupados por su tipo.", "Reporte de Equipos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ReporteSolicitudesPorFecha()
        {
            var solicitudes = DatosGlobales.ListaSolicitudes.ToList() ?? new List<Solicitud>();
            solicitudes.Sort((a, b) => a.FechaCreacion.CompareTo(b.FechaCreacion));

            var reporteFechas = solicitudes.Select(s => new
            {
                Codigo = s.CodigoSolicitud,
                FechaHora = s.FechaCreacion.ToString("yyyy-MM-dd HH:mm:ss"),
                Cliente = s.ClientePropietario != null ? s.ClientePropietario.NombreCompleto : "Sin cliente",
                Estado = s.Estado,
                Prioridad = s.Prioridad
            }).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reporteFechas;
            ConfigurarEstiloTabla();
            MessageBox.Show(this, "Reporte generado:\nSolicitudes ordenadas cronológicamente por fecha y hora.", "Reporte por Fechas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =========================================================================
        // MÉTODOS DE ORDENAMIENTO MANUAL (PUNTO 8)
        // =========================================================================
        public void EjecutarBubbleSortCosto()
        {
            var lista = DatosGlobales.ListaSolicitudes.ToList();
            DatosGlobales.OrdenarSolicitudesPorCostoBubbleSort(lista);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            ConfigurarEstiloTabla();
            MessageBox.Show(this, "Ordenamiento [Bubble Sort] aplicado:\nSolicitudes ordenadas por costo total de forma ascendente.", "Algoritmo Manual", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EjecutarSelectionSortTecnicos()
        {
            var lista = DatosGlobales.ListaTecnicos.ToList();
            DatosGlobales.OrdenarTecnicosPorServiciosSelectionSort(lista);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            ConfigurarEstiloTabla();
            MessageBox.Show(this, "Ordenamiento [Selection Sort] aplicado:\nTécnicos ordenados por cantidad de servicios finalizados.", "Algoritmo Manual", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EjecutarShellSortRepuestos()
        {
            var lista = DatosGlobales.ListaRepuestos.ToList();
            DatosGlobales.OrdenarRepuestosPorExistenciasShellSort(lista);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            ConfigurarEstiloTabla();
            MessageBox.Show(this, "Ordenamiento [Shell Sort] aplicado:\nRepuestos ordenados por existencias (cantidad disponible).", "Algoritmo Manual", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EjecutarInsertionSortTecnicos()
        {
            var lista = DatosGlobales.ListaTecnicos.ToList();
            DatosGlobales.OrdenarTecnicosPorServiciosInsertionSort(lista);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            ConfigurarEstiloTabla();
            MessageBox.Show(this, "Ordenamiento [Insertion Sort] aplicado:\nTécnicos ordenados por servicios de soporte.", "Algoritmo Manual", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =========================================================================
        // BOTÓN 6: VOLVER
        // =========================================================================
        private void button6_Click(object sender, EventArgs e)
        {
            Herramientas_y_consultas herramientasForm = new Herramientas_y_consultas();
            herramientasForm.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EjecutarBubbleSortCosto();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            EjecutarSelectionSortTecnicos();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EjecutarShellSortRepuestos();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            EjecutarInsertionSortTecnicos();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ReporteEquiposPorTipo();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ReporteSolicitudesPorFecha();
        }
    }
}