using System;
using System.Windows.Forms;

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

            // Inicializar datos de prueba automáticamente al arrancar la aplicación
            DatosGlobales.GenerarDatosPrueba();
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
            // Validar que el formulario exista antes de abrirlo para evitar excepciones
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
    }
}