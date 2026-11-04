namespace XelaTech
{
    partial class Herramientas_y_consultas
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            panel1 = new Panel();
            button6 = new Button();
            button5 = new Button();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 77);
            label1.Name = "label1";
            label1.Size = new Size(210, 23);
            label1.TabIndex = 0;
            label1.Text = "Herrramientas y Consultas";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(39, 39, 42);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(3, 133);
            button1.Name = "button1";
            button1.Size = new Size(232, 55);
            button1.TabIndex = 1;
            button1.Text = "Ordenamiento De Reportes y Estadisticas.";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(39, 39, 42);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 8.25F);
            button2.Location = new Point(3, 194);
            button2.Name = "button2";
            button2.Size = new Size(232, 55);
            button2.TabIndex = 2;
            button2.Text = "Modulo De Reportes y Estadisticas";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(39, 39, 42);
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft Sans Serif", 8.25F);
            button3.Location = new Point(3, 255);
            button3.Name = "button3";
            button3.Size = new Size(232, 63);
            button3.TabIndex = 3;
            button3.Text = "Generar Datos De Prueba";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(39, 39, 42);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Microsoft Sans Serif", 8.25F);
            button4.Location = new Point(3, 452);
            button4.Name = "button4";
            button4.Size = new Size(232, 57);
            button4.TabIndex = 4;
            button4.Text = "Volver al menú principal";
            button4.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(32, 32, 35);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(248, 518);
            panel1.TabIndex = 5;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(39, 39, 42);
            button6.Cursor = Cursors.Hand;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Microsoft Sans Serif", 8.25F);
            button6.Location = new Point(1, 391);
            button6.Name = "button6";
            button6.Size = new Size(232, 55);
            button6.TabIndex = 6;
            button6.Text = "Deshacer Estado";
            button6.UseVisualStyleBackColor = false;
            button6.Click += btnDeshacer_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(39, 39, 42);
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Microsoft Sans Serif", 8.25F);
            button5.Location = new Point(3, 324);
            button5.Name = "button5";
            button5.Size = new Size(232, 63);
            button5.TabIndex = 5;
            button5.Text = "Reportes Del Sistema";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 8.25F);
            label2.ForeColor = Color.FromArgb(249, 115, 22);
            label2.Location = new Point(69, 3);
            label2.Name = "label2";
            label2.Size = new Size(176, 35);
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
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(248, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(652, 518);
            panel2.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(17, 77);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(604, 369);
            dataGridView1.TabIndex = 0;
            // 
            // Herramientas_y_consultas
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(900, 518);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(250, 250, 249);
            Name = "Herramientas_y_consultas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Herramientas_y_consultas";
            Activated += Herramientas_y_consultas_Activated;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Panel panel1;
        private Label label2;
        private PictureBox pictureBox1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Button button5;
        private Button button6;
    }
}