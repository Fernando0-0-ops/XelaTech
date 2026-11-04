namespace XelaTech
{
    partial class Módulo_operativo
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            panel1 = new Panel();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            picLogo = new PictureBox();
            lblNombre = new Label();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            txtCriterio = new TextBox();
            button8 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(39, 39, 42);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(12, 96);
            button1.Name = "button1";
            button1.Size = new Size(195, 45);
            button1.TabIndex = 0;
            button1.Text = "Gestión De Solicitudes y Ordenes De Servicio";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.AccessibleRole = AccessibleRole.None;
            button2.BackColor = Color.FromArgb(39, 39, 42);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(12, 209);
            button2.Name = "button2";
            button2.Size = new Size(195, 56);
            button2.TabIndex = 1;
            button2.Text = "Atención de Colas y Prioridades";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(39, 39, 42);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(12, 519);
            button3.Name = "button3";
            button3.Size = new Size(195, 45);
            button3.TabIndex = 2;
            button3.Text = "Volver Al Menú Principal";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F);
            label1.ForeColor = Color.FromArgb(249, 115, 22);
            label1.Location = new Point(80, 35);
            label1.Name = "label1";
            label1.Size = new Size(120, 17);
            label1.TabIndex = 3;
            label1.Text = "Modulo Operativo";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(32, 32, 35);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(picLogo);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(lblNombre);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 603);
            panel1.TabIndex = 4;
            // 
            // button7
            // 
            button7.AccessibleRole = AccessibleRole.None;
            button7.BackColor = Color.FromArgb(39, 39, 42);
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Location = new Point(12, 457);
            button7.Name = "button7";
            button7.Size = new Size(195, 56);
            button7.TabIndex = 8;
            button7.Text = "Buscar solicitud (Binaria)";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.AccessibleRole = AccessibleRole.None;
            button6.BackColor = Color.FromArgb(39, 39, 42);
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(12, 395);
            button6.Name = "button6";
            button6.Size = new Size(195, 56);
            button6.TabIndex = 7;
            button6.Text = "Buscar Por Estado";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.AccessibleRole = AccessibleRole.None;
            button5.BackColor = Color.FromArgb(39, 39, 42);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(12, 333);
            button5.Name = "button5";
            button5.Size = new Size(195, 56);
            button5.TabIndex = 6;
            button5.Text = "Buscar Equipo Por Marca";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.AccessibleRole = AccessibleRole.None;
            button4.BackColor = Color.FromArgb(39, 39, 42);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(12, 271);
            button4.Name = "button4";
            button4.Size = new Size(195, 56);
            button4.TabIndex = 5;
            button4.Text = "Buscar Cliente";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = Properties.Resources.LLave_inglesa;
            picLogo.Location = new Point(5, 0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(60, 60);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 1;
            picLogo.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblNombre.ForeColor = Color.FromArgb(249, 115, 22);
            lblNombre.Location = new Point(12, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(200, 35);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "XelaTech";
            lblNombre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(txtCriterio);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(220, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(762, 603);
            panel2.TabIndex = 5;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(20, 136);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(705, 305);
            dataGridView1.TabIndex = 0;
            // 
            // txtCriterio
            // 
            txtCriterio.Location = new Point(20, 96);
            txtCriterio.Name = "txtCriterio";
            txtCriterio.Size = new Size(195, 30);
            txtCriterio.TabIndex = 4;
            txtCriterio.TextChanged += txtCriterio_TextChanged;
            // 
            // button8
            // 
            button8.AccessibleRole = AccessibleRole.None;
            button8.BackColor = Color.FromArgb(39, 39, 42);
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Location = new Point(12, 147);
            button8.Name = "button8";
            button8.Size = new Size(195, 56);
            button8.TabIndex = 9;
            button8.Text = "Registrar nueva solicitud";
            button8.UseVisualStyleBackColor = false;
            // 
            // Módulo_operativo
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            ClientSize = new Size(982, 603);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(250, 250, 249);
            MinimumSize = new Size(1000, 650);
            Name = "Módulo_operativo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Módulo_operativo";
            Activated += Módulo_operativo_Activated;
            Load += Módulo_operativo_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Panel panel1;
        private Label lblNombre;
        private PictureBox picLogo;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Button button4;
        private TextBox txtCriterio;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button8;
    }
}