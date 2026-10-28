using System;
using System.Windows.Forms;
using XelaTech.Modelos;
using Microsoft.VisualBasic;

namespace XelaTech
{
    public partial class Registros_base_y_recursos : Form
    {
        public Registros_base_y_recursos()
        {
            InitializeComponent();

            // Enlazamos los clics directamente a tus botones exactos
            if (button1 != null) button1.Click += (s, e) => { ActualizarTablaClientes(); if (MessageBox.Show("¿Desea registrar un nuevo cliente?", "Gestión de Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) RegistrarCliente(); };
            if (button2 != null) button2.Click += (s, e) => { ActualizarTablaTecnicos(); if (MessageBox.Show("¿Desea registrar un nuevo técnico?", "Gestión de Técnicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) RegistrarTecnico(); };
            if (button3 != null) button3.Click += (s, e) => { ActualizarTablaEquipos(); if (MessageBox.Show("¿Desea registrar un nuevo equipo?", "Gestión de Equipos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) RegistrarEquipo(); };
            if (button4 != null) button4.Click += (s, e) => { ActualizarTablaRepuestos(); if (MessageBox.Show("¿Desea registrar un nuevo repuesto?", "Gestión de Repuestos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) RegistrarRepuesto(); };
            if (button5 != null) button5.Click += (s, e) => { Form1 menuPrincipal = new Form1(); menuPrincipal.Show(); this.Close(); };
        }

        private void Registros_base_y_recursos_Load(object sender, EventArgs e)
        {
            ActualizarTablaClientes();
        }

        // Métodos de compatibilidad vacíos para el diseñador visual de VS
        private void button1_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }

        // ==========================================
        // MÉTODOS DE ACTUALIZACIÓN DE TABLAS
        // ==========================================
        private void ActualizarTablaClientes()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DatosGlobales.ListaClientes;
        }

        private void ActualizarTablaTecnicos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DatosGlobales.ListaTecnicos;
        }

        private void ActualizarTablaEquipos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DatosGlobales.ListaEquipos;
        }

        private void ActualizarTablaRepuestos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DatosGlobales.ListaRepuestos;
        }

        private string PedirDato(string mensaje)
        {
            return Interaction.InputBox(mensaje, "XELATECH SOPORTE").Trim();
        }

        // ==========================================
        // REGISTROS CON VALIDACIONES OBLIGATORIAS
        // ==========================================
        private void RegistrarCliente()
        {
            string codigo = PedirDato("Código del cliente (Ej: CLI-01):");
            string nombre = PedirDato("Nombre completo:");
            string telefono = PedirDato("Teléfono:");
            string correo = PedirDato("Correo electrónico:");
            string tipoCliente = PedirDato("Tipo de cliente (Estudiante, Profesional, Pequeño Negocio):");

            if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(tipoCliente))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var cliente in DatosGlobales.ListaClientes)
            {
                if (cliente.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El código de cliente ya existe en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Cliente nuevo = new Cliente(codigo, nombre, telefono, correo, tipoCliente);
            DatosGlobales.ListaClientes.Add(nuevo);
            ActualizarTablaClientes();

            MessageBox.Show("¡Cliente registrado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RegistrarTecnico()
        {
            string codigo = PedirDato("Código del técnico (Ej: TEC-01):");
            string nombre = PedirDato("Nombre completo:");
            string telefono = PedirDato("Teléfono:");
            string correo = PedirDato("Correo electrónico:");
            string especialidad = PedirDato("Especialidad (Computadora Portátil, Computadora Escritorio, Impresora):");

            if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(especialidad))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var tecnico in DatosGlobales.ListaTecnicos)
            {
                if (tecnico.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El código de técnico ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Tecnico nuevo = new Tecnico(codigo, nombre, telefono, correo, especialidad, 3);
            DatosGlobales.ListaTecnicos.Add(nuevo);
            ActualizarTablaTecnicos();

            MessageBox.Show("¡Técnico registrado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RegistrarEquipo()
        {
            string codigoInterno = PedirDato("Código interno del equipo:");
            string numeroSerie = PedirDato("Número de serie (Debe ser único):");
            string marca = PedirDato("Marca:");
            string modelo = PedirDato("Modelo:");
            string codigoCliente = PedirDato("Código del cliente propietario:");
            string tipoEquipo = PedirDato("Tipo de equipo (Portatil, Escritorio, Impresora):");
            string estadoFisico = PedirDato("Estado físico recibido:");
            string accesorios = PedirDato("Accesorios entregados:");

            if (string.IsNullOrEmpty(codigoInterno) || string.IsNullOrEmpty(numeroSerie) || string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(modelo) || string.IsNullOrEmpty(codigoCliente))
            {
                MessageBox.Show("Los campos obligatorios no pueden estar vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cliente propietario = null;
            foreach (var c in DatosGlobales.ListaClientes)
            {
                if (c.Codigo.Equals(codigoCliente, StringComparison.OrdinalIgnoreCase))
                {
                    propietario = c;
                    break;
                }
            }

            if (propietario == null)
            {
                MessageBox.Show("No se encontró ningún cliente registrado con ese código.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var eq in DatosGlobales.ListaEquipos)
            {
                if (eq.NumeroSerie.Equals(numeroSerie, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El número de serie ya se encuentra registrado en otro equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Equipo nuevoEquipo = null;
            string tipoLower = tipoEquipo.ToLower();

            if (tipoLower.Contains("portatil") || tipoLower.Contains("laptop"))
            {
                nuevoEquipo = new ComputadoraPortatil(codigoInterno, numeroSerie, marca, modelo, propietario, estadoFisico, accesorios, true);
            }
            else if (tipoLower.Contains("escritorio") || tipoLower.Contains("desktop"))
            {
                nuevoEquipo = new ComputadoraEscritorio(codigoInterno, numeroSerie, marca, modelo, propietario, estadoFisico, accesorios, false);
            }
            else if (tipoLower.Contains("impresora"))
            {
                nuevoEquipo = new Impresora(codigoInterno, numeroSerie, marca, modelo, propietario, estadoFisico, accesorios, "Cartucho/Tóner");
            }
            else
            {
                MessageBox.Show("Tipo de equipo no válido. Debe ser Portatil, Escritorio o Impresora.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DatosGlobales.ListaEquipos.Add(nuevoEquipo);
            ActualizarTablaEquipos();

            MessageBox.Show("¡Equipo registrado e instanciado polimórficamente con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RegistrarRepuesto()
        {
            string codigo = PedirDato("Código del repuesto (Ej: REP-01):");
            string nombre = PedirDato("Nombre del repuesto:");
            string categoria = PedirDato("Categoría:");
            string strExistencia = PedirDato("Existencia actual:");
            string strMinima = PedirDato("Existencia mínima de alerta:");
            string strCosto = PedirDato("Costo unitario:");
            string strPrecio = PedirDato("Precio de venta:");

            int existencia, minimo;
            double costo, precio;

            if (!int.TryParse(strExistencia, out existencia) || !int.TryParse(strMinima, out minimo) ||
                !double.TryParse(strCosto, out costo) || !double.TryParse(strPrecio, out precio) ||
                existencia < 0 || minimo < 0 || costo < 0 || precio < 0)
            {
                MessageBox.Show("Por favor ingrese valores numéricos válidos y no negativos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var r in DatosGlobales.ListaRepuestos)
            {
                if (r.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El código de repuesto ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Repuesto nuevoRepuesto = new Repuesto(codigo, nombre, categoria, existencia, minimo, costo, precio);
            DatosGlobales.ListaRepuestos.Add(nuevoRepuesto);
            ActualizarTablaRepuestos();

            MessageBox.Show("¡Repuesto registrado correctamente en el inventario!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }
    }
}