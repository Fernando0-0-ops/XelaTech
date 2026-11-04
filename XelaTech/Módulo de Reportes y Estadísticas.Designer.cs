namespace XelaTech
{
    partial class Módulo_de_Reportes_y_Estadísticas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Button button5;
            Button button11;
            Button button12;
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button6 = new Button();
            panel1 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button5 = new Button();
            button11 = new Button();
            button12 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(39, 39, 42);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(8, 346);
            button5.Name = "button5";
            button5.Size = new Size(192, 46);
            button5.TabIndex = 5;
            button5.Text = "Historial De Cambios De Estado Por Solicitud";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button11
            // 
            button11.BackColor = Color.FromArgb(39, 39, 42);
            button11.FlatStyle = FlatStyle.Flat;
            button11.Location = new Point(8, 398);
            button11.Name = "button11";
            button11.Size = new Size(192, 46);
            button11.TabIndex = 7;
            button11.Text = "Reporte de Equipos por Tipo.";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.BackColor = Color.FromArgb(39, 39, 42);
            button12.FlatStyle = FlatStyle.Flat;
            button12.Location = new Point(8, 450);
            button12.Name = "button12";
            button12.Size = new Size(192, 46);
            button12.TabIndex = 8;
            button12.Text = "Reporte de Solicitudes por Fecha.";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 76);
            label1.Name = "label1";
            label1.Size = new Size(138, 17);
            label1.TabIndex = 0;
            label1.Text = "Modulo De Reportes";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(39, 39, 42);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(8, 111);
            button1.Name = "button1";
            button1.Size = new Size(192, 54);
            button1.TabIndex = 1;
            button1.Text = "Reporte Financiero De Servicios";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(39, 39, 42);
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(8, 171);
            button2.Name = "button2";
            button2.Size = new Size(192, 54);
            button2.TabIndex = 2;
            button2.Text = "Reporte De Rendimiento y Carga De Tecnicos";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(39, 39, 42);
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(8, 231);
            button3.Name = "button3";
            button3.Size = new Size(192, 53);
            button3.TabIndex = 3;
            button3.Text = "Reporte De Equipos Con Mayor Incidencia";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(39, 39, 42);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(8, 290);
            button4.Name = "button4";
            button4.Size = new Size(192, 50);
            button4.TabIndex = 4;
            button4.Text = "Reporte De Inventario Critico";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(39, 39, 42);
            button6.Cursor = Cursors.Hand;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(8, 505);
            button6.Name = "button6";
            button6.Size = new Size(192, 46);
            button6.TabIndex = 6;
            button6.Text = "Volver Al Menú Principal";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(32, 32, 35);
            panel1.Controls.Add(button12);
            panel1.Controls.Add(button11);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 554);
            panel1.TabIndex = 7;
            // 
            // label2
            // 
            label2.ForeColor = Color.FromArgb(249, 115, 22);
            label2.Location = new Point(69, 3);
            label2.Name = "label2";
            label2.Size = new Size(69, 25);
            label2.TabIndex = 1;
            label2.Text = "XelaTech";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.LLave_inglesa;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(226, 111);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(695, 333);
            dataGridView1.TabIndex = 8;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(39, 39, 42);
            button7.Cursor = Cursors.Hand;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Location = new Point(226, 459);
            button7.Name = "button7";
            button7.Size = new Size(192, 54);
            button7.TabIndex = 7;
            button7.Text = "Ordenar por Costo (Bubble Sort)";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(39, 39, 42);
            button8.Cursor = Cursors.Hand;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Location = new Point(424, 459);
            button8.Name = "button8";
            button8.Size = new Size(192, 54);
            button8.TabIndex = 9;
            button8.Text = "Ordenar Técnicos (Selection Sort)";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(39, 39, 42);
            button9.Cursor = Cursors.Hand;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Location = new Point(622, 459);
            button9.Name = "button9";
            button9.Size = new Size(192, 54);
            button9.TabIndex = 10;
            button9.Text = "Ordenar Repuestos (Shell Sort)";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.FromArgb(39, 39, 42);
            button10.Cursor = Cursors.Hand;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Location = new Point(820, 459);
            button10.Name = "button10";
            button10.Size = new Size(192, 54);
            button10.TabIndex = 11;
            button10.Text = "Ordenar por Soporte (Insertion Sort)";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // Módulo_de_Reportes_y_Estadísticas
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(1071, 554);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            ForeColor = Color.FromArgb(250, 250, 249);
            MinimumSize = new Size(1000, 50);
            Name = "Módulo_de_Reportes_y_Estadísticas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Módulo_de_Reportes_y_Estadísticas";
            Activated += Módulo_de_Reportes_y_Estadísticas_Activated;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label2;
        private DataGridView dataGridView1;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
    }
}