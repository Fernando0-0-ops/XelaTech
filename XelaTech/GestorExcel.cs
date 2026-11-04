using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using XelaTech.Modelos;

namespace XelaTech
{
    public static class GestorExcel
    {
        private static readonly string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosXelaTech.xlsx");

        /// <summary>
        /// Guarda todas las listas globales (Clientes, Técnicos, Equipos, Repuestos y Solicitudes con Historial) en el archivo Excel.
        /// </summary>
        public static void GuardarTodo()
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    // ==========================================
                    // 1. Hoja de Clientes
                    // ==========================================
                    var wsClientes = workbook.Worksheets.Add("Clientes");
                    wsClientes.Cell(1, 1).Value = "Codigo";
                    wsClientes.Cell(1, 2).Value = "NombreCompleto";
                    wsClientes.Cell(1, 3).Value = "Telefono";
                    wsClientes.Cell(1, 4).Value = "Correo";
                    wsClientes.Cell(1, 5).Value = "TipoCliente";

                    int filaCliente = 2;
                    foreach (var cliente in DatosGlobales.ListaClientes)
                    {
                        if (cliente != null)
                        {
                            wsClientes.Cell(filaCliente, 1).Value = cliente.Codigo;
                            wsClientes.Cell(filaCliente, 2).Value = cliente.NombreCompleto;
                            wsClientes.Cell(filaCliente, 3).Value = cliente.Telefono;
                            wsClientes.Cell(filaCliente, 4).Value = cliente.Correo;
                            wsClientes.Cell(filaCliente, 5).Value = cliente.TipoCliente;
                            filaCliente++;
                        }
                    }

                    // ==========================================
                    // 2. Hoja de Técnicos
                    // ==========================================
                    var wsTecnicos = workbook.Worksheets.Add("Tecnicos");
                    wsTecnicos.Cell(1, 1).Value = "Codigo";
                    wsTecnicos.Cell(1, 2).Value = "Nombre";
                    wsTecnicos.Cell(1, 3).Value = "Especialidad";
                    wsTecnicos.Cell(1, 4).Value = "TrabajosActivos";
                    wsTecnicos.Cell(1, 5).Value = "ServiciosFinalizados";
                    wsTecnicos.Cell(1, 6).Value = "LimiteTrabajos";

                    int filaTecnico = 2;
                    foreach (var tecnico in DatosGlobales.ListaTecnicos)
                    {
                        if (tecnico != null)
                        {
                            wsTecnicos.Cell(filaTecnico, 1).Value = tecnico.Codigo;
                            wsTecnicos.Cell(filaTecnico, 2).Value = tecnico.NombreCompleto;
                            wsTecnicos.Cell(filaTecnico, 3).Value = tecnico.Especialidad;
                            wsTecnicos.Cell(filaTecnico, 4).Value = tecnico.TrabajosActivos;
                            wsTecnicos.Cell(filaTecnico, 5).Value = tecnico.ServiciosFinalizados;
                            wsTecnicos.Cell(filaTecnico, 6).Value = tecnico.LimiteTrabajos;
                            filaTecnico++;
                        }
                    }

                    // ==========================================
                    // 3. Hoja de Equipos
                    // ==========================================
                    var wsEquipos = workbook.Worksheets.Add("Equipos");
                    wsEquipos.Cell(1, 1).Value = "TipoEquipo";
                    wsEquipos.Cell(1, 2).Value = "CodigoInterno";
                    wsEquipos.Cell(1, 3).Value = "NumeroDeSerie";
                    wsEquipos.Cell(1, 4).Value = "Marca";
                    wsEquipos.Cell(1, 5).Value = "Modelo";
                    wsEquipos.Cell(1, 6).Value = "CodigoCliente";

                    int filaEquipo = 2;
                    foreach (var equipo in DatosGlobales.ListaEquipos)
                    {
                        if (equipo != null)
                        {
                            wsEquipos.Cell(filaEquipo, 1).Value = equipo.GetType().Name;
                            wsEquipos.Cell(filaEquipo, 2).Value = equipo.CodigoInterno;
                            wsEquipos.Cell(filaEquipo, 3).Value = equipo.NumeroDeSerie;
                            wsEquipos.Cell(filaEquipo, 4).Value = equipo.Marca;
                            wsEquipos.Cell(filaEquipo, 5).Value = equipo.Modelo;
                            wsEquipos.Cell(filaEquipo, 6).Value = equipo.Propietario != null ? equipo.Propietario.Codigo : "";
                            filaEquipo++;
                        }
                    }

                    // ==========================================
                    // 4. Hoja de Repuestos
                    // ==========================================
                    var wsRepuestos = workbook.Worksheets.Add("Repuestos");
                    wsRepuestos.Cell(1, 1).Value = "Codigo";
                    wsRepuestos.Cell(1, 2).Value = "Nombre";
                    wsRepuestos.Cell(1, 3).Value = "Categoria";
                    wsRepuestos.Cell(1, 4).Value = "CantidadDisponible";
                    wsRepuestos.Cell(1, 5).Value = "ExistenciaMinima";
                    wsRepuestos.Cell(1, 6).Value = "CostoUnitario";
                    wsRepuestos.Cell(1, 7).Value = "PrecioVenta";

                    int filaRepuesto = 2;
                    foreach (var rep in DatosGlobales.ListaRepuestos)
                    {
                        if (rep != null)
                        {
                            wsRepuestos.Cell(filaRepuesto, 1).Value = rep.Codigo;
                            wsRepuestos.Cell(filaRepuesto, 2).Value = rep.Nombre;
                            wsRepuestos.Cell(filaRepuesto, 3).Value = rep.Categoria;
                            wsRepuestos.Cell(filaRepuesto, 4).Value = rep.CantidadDisponible;
                            wsRepuestos.Cell(filaRepuesto, 5).Value = rep.ExistenciaMinima;
                            wsRepuestos.Cell(filaRepuesto, 6).Value = rep.CostoUnitario;
                            wsRepuestos.Cell(filaRepuesto, 7).Value = rep.PrecioVenta;
                            filaRepuesto++;
                        }
                    }

                    // ==========================================
                    // 5. Hoja de Solicitudes
                    // ==========================================
                    var wsSolicitudes = workbook.Worksheets.Add("Solicitudes");
                    wsSolicitudes.Cell(1, 1).Value = "CodigoSolicitud";
                    wsSolicitudes.Cell(1, 2).Value = "CodigoCliente";
                    wsSolicitudes.Cell(1, 3).Value = "CodigoEquipo";
                    wsSolicitudes.Cell(1, 4).Value = "Descripcion";
                    wsSolicitudes.Cell(1, 5).Value = "Prioridad";
                    wsSolicitudes.Cell(1, 6).Value = "EstadoActual";
                    wsSolicitudes.Cell(1, 7).Value = "FechaRecepcion";
                    wsSolicitudes.Cell(1, 8).Value = "CostoManoObra";
                    wsSolicitudes.Cell(1, 9).Value = "CodigoTecnico";
                    wsSolicitudes.Cell(1, 10).Value = "HistorialEstados";
                    wsSolicitudes.Cell(1, 11).Value = "RepuestosUtilizados";

                    int filaSolicitud = 2;
                    foreach (var sol in DatosGlobales.ListaSolicitudes)
                    {
                        if (sol != null)
                        {
                            wsSolicitudes.Cell(filaSolicitud, 1).Value = sol.CodigoSolicitud;
                            wsSolicitudes.Cell(filaSolicitud, 2).Value = sol.Cliente != null ? sol.Cliente.Codigo : "";
                            wsSolicitudes.Cell(filaSolicitud, 3).Value = sol.Equipo != null ? sol.Equipo.CodigoInterno : "";
                            wsSolicitudes.Cell(filaSolicitud, 4).Value = sol.DescripcionProblema;
                            wsSolicitudes.Cell(filaSolicitud, 5).Value = sol.Prioridad;
                            wsSolicitudes.Cell(filaSolicitud, 6).Value = sol.Estado;
                            wsSolicitudes.Cell(filaSolicitud, 7).Value = sol.FechaHoraRecepcion.ToString("yyyy-MM-dd HH:mm:ss");
                            wsSolicitudes.Cell(filaSolicitud, 8).Value = sol.CostoManoObra;
                            wsSolicitudes.Cell(filaSolicitud, 9).Value = sol.TecnicoAsignado != null ? sol.TecnicoAsignado.Codigo : "";

                            string historialStr = sol.HistorialEstados != null && sol.HistorialEstados.Count > 0
                                ? string.Join(",", sol.HistorialEstados.Reverse())
                                : sol.Estado;
                            wsSolicitudes.Cell(filaSolicitud, 10).Value = historialStr;

                            string repuestosStr = "NINGUNO";
                            if (sol.RepuestosUtilizados != null && sol.RepuestosUtilizados.Count > 0)
                            {
                                repuestosStr = string.Join(";", sol.RepuestosUtilizados.Select(ru => $"{ru.RepuestoInfo.Codigo}:{ru.Cantidad}"));
                            }
                            wsSolicitudes.Cell(filaSolicitud, 11).Value = repuestosStr;

                            filaSolicitud++;
                        }
                    }

                    workbook.SaveAs(rutaArchivo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar los datos en Excel: " + ex.Message);
            }
        }

        /// <summary>
        /// Lee el archivo Excel al iniciar la aplicación restaurando íntegramente todos los objetos.
        /// </summary>
        public static void CargarTodo()
        {
            if (!File.Exists(rutaArchivo)) return;

            try
            {
                using (var workbook = new XLWorkbook(rutaArchivo))
                {
                    // 1. Cargar Clientes
                    if (workbook.Worksheets.Contains("Clientes"))
                    {
                        var wsClientes = workbook.Worksheet("Clientes");
                        DatosGlobales.ListaClientes.Clear();

                        foreach (var row in wsClientes.RowsUsed().Skip(1))
                        {
                            string codigo = row.Cell(1).GetValue<string>();
                            string nombre = row.Cell(2).GetValue<string>();
                            string telefono = row.Cell(3).GetValue<string>();
                            string correo = row.Cell(4).GetValue<string>();
                            string tipo = row.Cell(5).GetValue<string>();

                            if (!string.IsNullOrWhiteSpace(codigo))
                            {
                                Cliente cliente = new Cliente(codigo, nombre, telefono, correo, string.IsNullOrEmpty(tipo) ? "Regular" : tipo);
                                DatosGlobales.ListaClientes.Add(cliente);
                            }
                        }
                    }

                    // 2. Cargar Técnicos
                    if (workbook.Worksheets.Contains("Tecnicos"))
                    {
                        var wsTecnicos = workbook.Worksheet("Tecnicos");
                        DatosGlobales.ListaTecnicos.Clear();

                        foreach (var row in wsTecnicos.RowsUsed().Skip(1))
                        {
                            string codigo = row.Cell(1).GetValue<string>();
                            string nombre = row.Cell(2).GetValue<string>();
                            string especialidad = row.Cell(3).GetValue<string>();
                            int trabajosActivos = 0;
                            int.TryParse(row.Cell(4).GetValue<string>(), out trabajosActivos);
                            int serviciosFin = 0;
                            int.TryParse(row.Cell(5).GetValue<string>(), out serviciosFin);
                            int limite = 3;
                            int.TryParse(row.Cell(6).GetValue<string>(), out limite);

                            if (!string.IsNullOrWhiteSpace(codigo))
                            {
                                Tecnico tecnico = new Tecnico();
                                tecnico.Codigo = codigo;
                                tecnico.NombreCompleto = nombre;
                                tecnico.Especialidad = especialidad;
                                tecnico.TrabajosActivos = trabajosActivos;
                                tecnico.ServiciosFinalizados = serviciosFin;
                                tecnico.LimiteTrabajos = limite > 0 ? limite : 3;
                                DatosGlobales.ListaTecnicos.Add(tecnico);
                            }
                        }
                    }

                    // 3. Cargar Equipos
                    if (workbook.Worksheets.Contains("Equipos"))
                    {
                        var wsEquipos = workbook.Worksheet("Equipos");
                        DatosGlobales.ListaEquipos.Clear();

                        foreach (var row in wsEquipos.RowsUsed().Skip(1))
                        {
                            string tipoReal = row.Cell(1).GetValue<string>();
                            string codigoInterno = row.Cell(2).GetValue<string>();
                            string numeroSerie = row.Cell(3).GetValue<string>();
                            string marca = row.Cell(4).GetValue<string>();
                            string modelo = row.Cell(5).GetValue<string>();
                            string codigoCliente = row.Cell(6).GetValue<string>();

                            if (!string.IsNullOrWhiteSpace(codigoInterno))
                            {
                                Cliente clienteProp = DatosGlobales.ListaClientes.FirstOrDefault(c => c.Codigo == codigoCliente);
                                Equipo equipo = null;

                                if (tipoReal != null && tipoReal.Contains("Portatil"))
                                {
                                    equipo = new ComputadoraPortatil(codigoInterno, string.IsNullOrEmpty(numeroSerie) ? "SN-001" : numeroSerie, marca, modelo, clienteProp, "Buen estado", "Ninguno", false);
                                }
                                else if (tipoReal != null && tipoReal.Contains("Impresora"))
                                {
                                    equipo = new Impresora(codigoInterno, string.IsNullOrEmpty(numeroSerie) ? "SN-002" : numeroSerie, marca, modelo, clienteProp, "Buen estado", "Inyección", true);
                                }
                                else
                                {
                                    equipo = new ComputadoraEscritorio(codigoInterno, string.IsNullOrEmpty(numeroSerie) ? "SN-003" : numeroSerie, marca, modelo, clienteProp, "Buen estado", "Ninguno", false);
                                }

                                DatosGlobales.ListaEquipos.Add(equipo);
                            }
                        }
                    }

                    // 4. Cargar Repuestos
                    if (workbook.Worksheets.Contains("Repuestos"))
                    {
                        var wsRepuestos = workbook.Worksheet("Repuestos");
                        DatosGlobales.ListaRepuestos.Clear();

                        foreach (var row in wsRepuestos.RowsUsed().Skip(1))
                        {
                            string codigo = row.Cell(1).GetValue<string>();
                            string nombre = row.Cell(2).GetValue<string>();
                            string categoria = row.Cell(3).GetValue<string>();
                            int cantidad = 0;
                            int.TryParse(row.Cell(4).GetValue<string>(), out cantidad);
                            int minimo = 0;
                            int.TryParse(row.Cell(5).GetValue<string>(), out minimo);
                            double costo = 0;
                            double.TryParse(row.Cell(6).GetValue<string>(), out costo);
                            double precio = 0;
                            double.TryParse(row.Cell(7).GetValue<string>(), out precio);

                            if (!string.IsNullOrWhiteSpace(codigo))
                            {
                                Repuesto rep = new Repuesto(codigo, nombre, categoria, cantidad, minimo, costo, precio);
                                DatosGlobales.ListaRepuestos.Add(rep);
                            }
                        }
                    }

                    // 5. Cargar Solicitudes
                    if (workbook.Worksheets.Contains("Solicitudes"))
                    {
                        var wsSolicitudes = workbook.Worksheet("Solicitudes");
                        DatosGlobales.ListaSolicitudes.Clear();

                        foreach (var row in wsSolicitudes.RowsUsed().Skip(1))
                        {
                            string codSol = row.Cell(1).GetValue<string>();
                            string codCli = row.Cell(2).GetValue<string>();
                            string codEq = row.Cell(3).GetValue<string>();
                            string desc = row.Cell(4).GetValue<string>();
                            string prio = row.Cell(5).GetValue<string>();
                            string estadoDestino = row.Cell(6).GetValue<string>();
                            string fechaStr = row.Cell(7).GetValue<string>();
                            double costo = 0;
                            double.TryParse(row.Cell(8).GetValue<string>(), out costo);
                            string codTec = row.Cell(9).GetValue<string>();
                            string historialStr = row.Cell(10).GetValue<string>();
                            string repuestosData = row.Cell(11).GetValue<string>();

                            if (!string.IsNullOrWhiteSpace(codSol))
                            {
                                Cliente cli = DatosGlobales.ListaClientes.FirstOrDefault(c => c.Codigo == codCli);
                                Equipo eq = DatosGlobales.ListaEquipos.FirstOrDefault(e => e.CodigoInterno == codEq);
                                Tecnico tec = DatosGlobales.ListaTecnicos.FirstOrDefault(t => t.Codigo == codTec);

                                Solicitud solicitud = new Solicitud(codSol, cli, eq, desc, prio);
                                solicitud.CostoManoObra = costo;
                                if (tec != null) solicitud.TecnicoAsignado = tec;

                                DateTime fecha;
                                if (DateTime.TryParse(fechaStr, out fecha))
                                {
                                    solicitud.FechaHoraRecepcion = fecha;
                                }

                                if (!string.IsNullOrEmpty(historialStr))
                                {
                                    solicitud.HistorialEstados.Clear();
                                    string[] estados = historialStr.Split(',');
                                    foreach (var est in estados)
                                    {
                                        if (!string.IsNullOrEmpty(est))
                                            solicitud.HistorialEstados.Push(est);
                                    }
                                }

                                if (!string.IsNullOrEmpty(estadoDestino))
                                {
                                    while (solicitud.Estado != estadoDestino && solicitud.HistorialEstados.Count > 0)
                                    {
                                        solicitud.CambiarEstado(estadoDestino);
                                    }
                                }

                                if (!string.IsNullOrEmpty(repuestosData) && repuestosData != "NINGUNO")
                                {
                                    string[] itemsRep = repuestosData.Split(';');
                                    foreach (var item in itemsRep)
                                    {
                                        string[] subPartes = item.Split(':');
                                        if (subPartes.Length == 2)
                                        {
                                            string codRep = subPartes[0];
                                            int cant = 0;
                                            int.TryParse(subPartes[1], out cant);

                                            Repuesto repObj = DatosGlobales.ListaRepuestos.FirstOrDefault(r => r.Codigo.Equals(codRep, StringComparison.OrdinalIgnoreCase));
                                            if (repObj != null && cant > 0)
                                            {
                                                solicitud.RepuestosUtilizados.Add(new RepuestoUsado(repObj, cant));
                                            }
                                        }
                                    }
                                }

                                DatosGlobales.ListaSolicitudes.Add(solicitud);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los datos desde Excel: " + ex.Message);
            }
        }
    }
}