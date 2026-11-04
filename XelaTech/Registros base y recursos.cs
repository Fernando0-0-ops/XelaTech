using System;
using System.Windows.Forms;
using XelaTech.Modelos;
using Microsoft.VisualBasic;

namespace XelaTech
{
    public partial class Registros_base_y_recursos : Form
    {
        private string tablaActual = "Clientes";

        public Registros_base_y_recursos()
        {
            InitializeComponent();

            if (dataGridView1 != null)
            {
                dataGridView1.DataError += (s, e) => { e.ThrowException = false; };
            }

            if (button1 != null) button1.Click += button1_Click;
            if (button2 != null) button2.Click += button2_Click;
            if (button3 != null) button3.Click += button3_Click;
            if (button4 != null) button4.Click += button4_Click;
            if (button5 != null) button5.Click += button5_Click;
        }

        private void Registros_base_y_recursos_Load(object sender, EventArgs e)
        {
            ActualizarTablaClientes();
        }

        private void ActualizarTablaClientes()
        {
            tablaActual = "Clientes";
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DatosGlobales.ListaClientes;
        }

        private void ActualizarTablaTecnicos()
        {
            tablaActual = "Tecnicos";
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DatosGlobales.ListaTecnicos;
        }

        private void ActualizarTablaEquipos()
        {
            tablaActual = "Equipos";
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DatosGlobales.ListaEquipos;
        }

        private void ActualizarTablaRepuestos()
        {
            tablaActual = "Repuestos";
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DatosGlobales.ListaRepuestos;
        }

        private string PedirDato(string mensaje)
        {
            return Interaction.InputBox(mensaje, "XELATECH SOPORTE").Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tablaActual != "Clientes")
            {
                ActualizarTablaClientes();
            }
            else
            {
                if (MessageBox.Show("¿Desea registrar un nuevo cliente?", "Gestión de Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string codigo = PedirDato("Código del cliente (Ej: CLI-01):");
                    string nombre = PedirDato("Nombre completo:");
                    string telefono = PedirDato("Teléfono:");
                    string correo = PedirDato("Correo electrónico:");
                    string tipoCliente = PedirDato("Tipo de cliente (Estudiante, Profesional, Pequeño Negocio):");

                    // 1. Comprobar campos obligatorios
                    if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(nombre))
                    {
                        MessageBox.Show("El código y el nombre del cliente son campos obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Validar que no se registren dos clientes con el mismo código
                    bool codigoRepetido = false;
                    foreach (var c in DatosGlobales.ListaClientes)
                    {
                        if (c.Codigo != null && c.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                        {
                            codigoRepetido = true;
                            break;
                        }
                    }

                    if (codigoRepetido)
                    {
                        MessageBox.Show($"Ya existe un cliente registrado con el código '{codigo}'. No se permiten códigos duplicados.", "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Registro exitoso
                    Cliente nuevo = new Cliente(codigo, nombre, telefono, correo, tipoCliente);
                    DatosGlobales.ListaClientes.Add(nuevo);
                    ActualizarTablaClientes();

                    MessageBox.Show("¡Cliente registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaActual != "Tecnicos")
            {
                ActualizarTablaTecnicos();
            }
            else
            {
                if (MessageBox.Show("¿Desea registrar un nuevo técnico?", "Gestión de Técnicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string codigo = PedirDato("Código del técnico (Ej: TEC-01):");
                    string nombre = PedirDato("Nombre completo:");
                    string telefono = PedirDato("Teléfono:");
                    string correo = PedirDato("Correo electrónico:");
                    string especialidad = PedirDato("Especialidad:");

                    // 1. Comprobar campos obligatorios
                    if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(nombre))
                    {
                        MessageBox.Show("El código y el nombre del técnico son obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Validar que el código del técnico sea único
                    bool codigoRepetido = false;
                    foreach (var t in DatosGlobales.ListaTecnicos)
                    {
                        if (t.CodigoTecnico != null && t.CodigoTecnico.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                        {
                            codigoRepetido = true;
                            break;
                        }
                    }

                    if (codigoRepetido)
                    {
                        MessageBox.Show($"Ya existe un técnico registrado con el código '{codigo}'. No se permiten códigos duplicados.", "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Registro exitoso
                    Tecnico nuevo = new Tecnico(codigo, nombre, telefono, correo, especialidad, 3);
                    DatosGlobales.ListaTecnicos.Add(nuevo);
                    ActualizarTablaTecnicos();

                    MessageBox.Show("¡Técnico registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tablaActual != "Equipos")
            {
                ActualizarTablaEquipos();
            }
            else
            {
                if (MessageBox.Show("¿Desea registrar un nuevo equipo?", "Gestión de Equipos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string tipoEquipo = PedirDato("Tipo de equipo (Portatil, Escritorio, Impresora):");
                    string codigoInterno = PedirDato("Código interno del equipo (Ej: EQ-01):");
                    string numeroSerie = PedirDato("Número de serie:");
                    string marca = PedirDato("Marca:");
                    string modelo = PedirDato("Modelo:");
                    string estadoFisico = PedirDato("Estado físico del equipo (Ej: Buen estado, Rayado, Pantalla rota):");
                    string accesorios = PedirDato("Accesorios entregados (Ej: Cargador, Funda, Ninguno):");
                    string codigoCliente = PedirDato("Código del cliente propietario:");

                    // 1. Comprobar campos obligatorios
                    if (string.IsNullOrEmpty(codigoInterno) || string.IsNullOrEmpty(numeroSerie) || string.IsNullOrEmpty(tipoEquipo))
                    {
                        MessageBox.Show("El tipo de equipo, código interno y número de serie son obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Validar duplicados de código interno y número de serie
                    foreach (var eq in DatosGlobales.ListaEquipos)
                    {
                        if (eq.CodigoInterno != null && eq.CodigoInterno.Equals(codigoInterno, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show($"Ya existe un equipo registrado con el código interno '{codigoInterno}'.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (eq.NumeroSerie != null && eq.NumeroSerie.Equals(numeroSerie, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show($"Ya existe un equipo registrado con el número de serie '{numeroSerie}'.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 3. Comprobar que el cliente propietario exista
                    Cliente propietario = null;
                    foreach (var c in DatosGlobales.ListaClientes)
                    {
                        if (c.Codigo != null && c.Codigo.Equals(codigoCliente, StringComparison.OrdinalIgnoreCase))
                        {
                            propietario = c;
                            break;
                        }
                    }

                    if (propietario == null)
                    {
                        MessageBox.Show("No se encontró ningún cliente registrado con ese código.", "Cliente No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Si no ingresó estado o accesorios, asignamos un valor por defecto
                    if (string.IsNullOrEmpty(estadoFisico)) estadoFisico = "Buen estado";
                    if (string.IsNullOrEmpty(accesorios)) accesorios = "Ninguno";

                    // 4. Instanciar el equipo correspondiente
                    Equipo nuevoEquipo = null;

                    if (tipoEquipo.Equals("Portatil", StringComparison.OrdinalIgnoreCase) || tipoEquipo.Equals("Portátil", StringComparison.OrdinalIgnoreCase))
                    {
                        string bateria = PedirDato("¿Tiene la batería dañada? (Si / No):");
                        bool tieneBateriaDañada = bateria.Equals("Si", StringComparison.OrdinalIgnoreCase) || bateria.Equals("Sí", StringComparison.OrdinalIgnoreCase);

                        nuevoEquipo = new ComputadoraPortatil(codigoInterno, numeroSerie, marca, modelo, propietario, estadoFisico, accesorios, tieneBateriaDañada);
                    }
                    else if (tipoEquipo.Equals("Escritorio", StringComparison.OrdinalIgnoreCase))
                    {
                        string factorForma = PedirDato("Factor de forma (Ej: Minitorre, Gamer, SFF):");
                        if (string.IsNullOrEmpty(factorForma)) factorForma = "Torre estándar";

                        nuevoEquipo = new ComputadoraEscritorio(codigoInterno, numeroSerie, marca, modelo, propietario, estadoFisico, accesorios, factorForma);
                    }
                    else if (tipoEquipo.Equals("Impresora", StringComparison.OrdinalIgnoreCase))
                    {
                        string tipoImpresora = PedirDato("Tipo de impresora (Ej: Inyección a Color, Láser Monocromática):");
                        if (string.IsNullOrEmpty(tipoImpresora)) tipoImpresora = "Inyección a Color";

                        nuevoEquipo = new Impresora(codigoInterno, numeroSerie, marca, modelo, propietario, estadoFisico, accesorios, tipoImpresora);
                    }
                    else
                    {
                        MessageBox.Show("Tipo de equipo no válido. Debe ser: Portatil, Escritorio o Impresora.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DatosGlobales.ListaEquipos.Add(nuevoEquipo);
                    ActualizarTablaEquipos();

                    MessageBox.Show("¡Equipo registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tablaActual != "Repuestos")
            {
                ActualizarTablaRepuestos();
            }
            else
            {
                DialogResult respuesta = MessageBox.Show(
                    "¿Desea registrar un nuevo repuesto?\n\n(Pulse 'Sí' para crear uno nuevo, o 'No' para actualizar el stock de uno existente)",
                    "Gestión de Repuestos",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    RegistrarRepuesto();
                }
                else if (respuesta == DialogResult.No)
                {
                    ActualizarStockRepuesto();
                }
            }
        }

        private void RegistrarRepuesto()
        {
            string codigo = PedirDato("Código del repuesto (Ej: REP-01):");
            string nombre = PedirDato("Nombre del repuesto:");
            string categoria = PedirDato("Categoría:");
            int existencia = 10;
            int.TryParse(PedirDato("Existencia actual:"), out existencia);
            double precio = 50.0;
            double.TryParse(PedirDato("Precio de venta:"), out precio);

            if (string.IsNullOrEmpty(codigo)) return;

            Repuesto nuevoRepuesto = new Repuesto(codigo, nombre, categoria, existencia, 2, 25.0, precio);
            DatosGlobales.ListaRepuestos.Add(nuevoRepuesto);
            ActualizarTablaRepuestos();
        }

        private void ActualizarStockRepuesto()
        {
            string codigo = PedirDato("Ingrese el código del repuesto a reabastecer (Ej: REP-001):");
            if (string.IsNullOrEmpty(codigo)) return;

            Repuesto repuestoEncontrado = null;
            foreach (var r in DatosGlobales.ListaRepuestos)
            {
                if (r.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                {
                    repuestoEncontrado = r;
                    break;
                }
            }

            if (repuestoEncontrado == null)
            {
                MessageBox.Show("No se encontró ningún repuesto registrado con ese código.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strCantidad = PedirDato($"Repuesto: {repuestoEncontrado.Nombre}\nExistencia actual: {repuestoEncontrado.CantidadDisponible}\n\nIngrese cuántas unidades desea agregar al stock:");
            int cantidadAgregar;

            if (!int.TryParse(strCantidad, out cantidadAgregar) || cantidadAgregar <= 0)
            {
                MessageBox.Show("Por favor ingrese una cantidad numérica válida mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            repuestoEncontrado.CantidadDisponible += cantidadAgregar;
            ActualizarTablaRepuestos();

            MessageBox.Show($"¡Stock actualizado con éxito! Nueva existencia total: {repuestoEncontrado.CantidadDisponible}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 menuPrincipal = new Form1();
            menuPrincipal.Show();
            this.Close();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            // Requerido por el diseñador
        }
        private void Registros_base_y_recursos_Activated(object sender, EventArgs e)
        {
            // Método requerido por el diseñador de Windows Forms
        }
    }
}