namespace XelaTech
{
    partial class Registros_base_y_recursos
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
            button5 = new Button();
            pnlMenu = new Panel();
            lblTitulo = new Label();
            Logo = new PictureBox();
            Contenido = new Panel();
            dataGridView1 = new DataGridView();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
            Contenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F);
            label1.ForeColor = Color.FromArgb(249, 115, 22);
            label1.Location = new Point(6, 69);
            label1.Name = "label1";
            label1.Size = new Size(214, 17);
            label1.TabIndex = 0;
            label1.Text = "REGISTRO BASE Y RECURSOS";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(39, 39, 42);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 8.25F);
            button1.ForeColor = Color.FromArgb(250, 250, 249);
            button1.Location = new Point(12, 130);
            button1.Name = "button1";
            button1.Size = new Size(195, 45);
            button1.TabIndex = 1;
            button1.Text = "Gestión De Clientes";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(39, 39, 42);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F);
            button2.ForeColor = Color.FromArgb(250, 250, 249);
            button2.Location = new Point(12, 181);
            button2.Name = "button2";
            button2.Size = new Size(195, 45);
            button2.TabIndex = 2;
            button2.Text = "Gestión De Tecnicos";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(39, 39, 42);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 10F);
            button3.ForeColor = Color.FromArgb(250, 250, 249);
            button3.Location = new Point(12, 232);
            button3.Name = "button3";
            button3.Size = new Size(195, 45);
            button3.TabIndex = 3;
            button3.Text = "Gestión De Equipos";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(39, 39, 42);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 10F);
            button4.ForeColor = Color.FromArgb(250, 250, 249);
            button4.Location = new Point(12, 283);
            button4.Name = "button4";
            button4.Size = new Size(195, 45);
            button4.TabIndex = 4;
            button4.Text = "Gestión De Repuestos";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(39, 39, 42);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 10F);
            button5.ForeColor = Color.FromArgb(250, 250, 249);
            button5.Location = new Point(12, 334);
            button5.Name = "button5";
            button5.Size = new Size(195, 45);
            button5.TabIndex = 5;
            button5.Text = "Volver Al Menú Principal";
            button5.UseVisualStyleBackColor = false;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(32, 32, 35);
            pnlMenu.Controls.Add(label1);
            pnlMenu.Controls.Add(lblTitulo);
            pnlMenu.Controls.Add(Logo);
            pnlMenu.Controls.Add(button5);
            pnlMenu.Controls.Add(button4);
            pnlMenu.Controls.Add(button1);
            pnlMenu.Controls.Add(button3);
            pnlMenu.Controls.Add(button2);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(220, 450);
            pnlMenu.TabIndex = 6;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblTitulo.ForeColor = Color.FromArgb(249, 115, 22);
            lblTitulo.Location = new Point(68, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(68, 17);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "XelaTech";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // Logo
            // 
            Logo.BackColor = Color.Transparent;
            Logo.Image = Properties.Resources.LLave_inglesa;
            Logo.Location = new Point(2, 2);
            Logo.Name = "Logo";
            Logo.Size = new Size(60, 60);
            Logo.SizeMode = PictureBoxSizeMode.Zoom;
            Logo.TabIndex = 0;
            Logo.TabStop = false;
            // 
            // Contenido
            // 
            Contenido.BackColor = Color.FromArgb(24, 24, 27);
            Contenido.Controls.Add(dataGridView1);
            Contenido.Dock = DockStyle.Fill;
            Contenido.Font = new Font("Microsoft Sans Serif", 8.25F);
            Contenido.Location = new Point(220, 0);
            Contenido.Name = "Contenido";
            Contenido.Size = new Size(580, 450);
            Contenido.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(18, 69);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(535, 310);
            dataGridView1.TabIndex = 0;
            // 
            // Registros_base_y_recursos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Contenido);
            Controls.Add(pnlMenu);
            Cursor = Cursors.Hand;
            Name = "Registros_base_y_recursos";
            Text = "Registros_base_y_recursos";
            Activated += Registros_base_y_recursos_Activated;
            Load += Registros_base_y_recursos_Load;
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
            Contenido.ResumeLayout(false);
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
        private Panel pnlMenu;
        private PictureBox Logo;
        private Panel Contenido;
        private Label lblTitulo;
        private DataGridView dataGridView1;
    }
}