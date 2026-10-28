using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XelaTech.Modelos;

namespace XelaTech
{
    public partial class Herramientas_y_consultas : Form
    {
        public Herramientas_y_consultas()
        {
            InitializeComponent();
        }

        private void Herramientas_y_consultas_Load(object sender, EventArgs e)
        {
            CargarTodasLasSolicitudes();

            // Enlace dinámico de los botones basándose en los textos del diseño visual
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Click -= Boton_Click;
                    btn.Click += Boton_Click;
                }
            }
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                string textoBoton = btn.Text.Trim();

                if (textoBoton.Contains("Ordenamiento") || textoBoton.Contains("Estadisticas"))
                {
                    OrdenarPorCostoManoObra();
                }
                else if (textoBoton.Contains("Modulo De Reportes") || textoBoton.Contains("Reportes"))
                {
                    // Despliegue de información o apertura del submódulo de reportes y matriz de carga
                    MessageBox.Show("Módulo de Reportes, Estadísticas y Matriz de Carga de Técnicos activo.",
                        "XelaTech - Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (textoBoton.Contains("Generar Datos De Prueba"))
                {
                    // Carga masiva de datos mediante generador respetando validaciones
                    GeneradorDatos.CargarDatosIniciales();
                    CargarTodasLasSolicitudes();
                    MessageBox.Show(
                        "¡Datos de prueba generados y cargados exitosamente en las estructuras!",
                        "Generador de Datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else if (textoBoton.Contains("Volver"))
                {
                    Form1 menu = new Form1();
                    menu.Show();
                    this.Close();
                }
            }
        }

        private void CargarTodasLasSolicitudes()
        {
            if (dataGridView1 != null)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DatosGlobales.ListaSolicitudes;
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
    }
}