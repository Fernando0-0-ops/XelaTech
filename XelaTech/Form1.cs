using System;
using System.Windows.Forms;
using XelaTech.Modelos;

namespace XelaTech
{
    public partial class Form1 : Form
    {
        int x;
        int y;
        bool move = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            x = e.X;
            y = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registros_base_y_recursos formRegistros = new Registros_base_y_recursos();
            formRegistros.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Herramientas_y_consultas formHerramientas = new Herramientas_y_consultas();
            formHerramientas.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Módulo_operativo formOperativo = new Módulo_operativo();
            formOperativo.Show();
            this.Hide();
        }

        // Se ejecuta automáticamente al abrir la aplicación
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Intentamos cargar los datos guardados en el Excel
                GestorExcel.CargarTodo();

                // Si es la primera vez que se abre la app y no hay datos cargados, generamos los de prueba
                if (DatosGlobales.ListaClientes.Count == 0 && DatosGlobales.ListaTecnicos.Count == 0)
                {
                    GeneradorDatos.GenerarDatosPrueba();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Se ejecuta automáticamente al cerrar la aplicación 
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                GestorExcel.GuardarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        // Botón de Salida (button4) configurado para cerrar la aplicación por completo
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de que deseas salir del sistema?",
                "XelaTech - Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit(); // Esto cerrará el formulario principal, activará el evento FormClosing (guardando en Excel) y apagará el programa por completo.
            }
        }
    }
}