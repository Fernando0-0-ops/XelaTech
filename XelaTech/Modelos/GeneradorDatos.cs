using System;
using System.Collections.Generic;
using System.Linq;
using XelaTech.Modelos;

namespace XelaTech.Modelos
{
    public static class GeneradorDatos
    {
        private static Random random = new Random();

        public static string CargarDatosIniciales() => EjecutarGeneracionPruebas();
        public static string GenerarDatosPrueba() => EjecutarGeneracionPruebas();

        public static string EjecutarGeneracionPruebas(int numClientes = 6, int numTecnicos = 5, int numEquipos = 8, int numSolicitudes = 10, int numRepuestos = 8)
        {
            string[] nombres = { "Carlos", "Ana", "Luis", "María", "José", "Sofía", "Pedro", "Lucía", "Jorge", "Elena" };
            string[] apellidos = { "Gómez", "Pérez", "López", "Rodríguez", "Hernández", "Morales", "Castillo", "Ortiz" };
            string[] tiposClientes = { "Estudiante", "Profesional", "Pequeño negocio" };
            string[] dominiosCorreo = { "gmail.com", "yahoo.com", "outlook.com", "xelatech.gt", "empresa.net" };
            string[] marcas = { "Dell", "HP", "Lenovo", "Asus", "Acer", "Toshiba", "Epson", "Brother" };
            string[] estadosFisicos = { "Buen estado", "Leve rayón en carcasa", "Desgaste normal por uso", "Golpe leve en esquina", "Excelente estado general", "Marcas de uso en tapa" };
            string[] problemas = { "No enciende", "Pantalla azul", "Lentitud extrema", "Mantenimiento preventivo", "Cambio de disco", "Virus y malware", "No imprime" };
            string[] especialidadesDisponibles = { "Portátil", "Escritorio", "Impresora", "Todos" };

            var repuestosBase = new[]
            {
                new { Nombre = "Memoria RAM 8GB DDR4", Categoria = "Memoria RAM", CostoMin = 180.0, CostoMax = 280.0 },
                new { Nombre = "Disco Sólido SSD 500GB", Categoria = "Almacenamiento", CostoMin = 250.0, CostoMax = 400.0 },
                new { Nombre = "Fuente de Poder 500W", Categoria = "Energía y Fuentes", CostoMin = 200.0, CostoMax = 350.0 },
                new { Nombre = "Pasta Térmica Alta Gama", Categoria = "Mantenimiento", CostoMin = 45.0, CostoMax = 90.0 },
                new { Nombre = "Teclado Repuesto Laptop", Categoria = "Periféricos", CostoMin = 120.0, CostoMax = 220.0 },
                new { Nombre = "Pantalla LED 15.6 Pulgadas", Categoria = "Pantallas", CostoMin = 450.0, CostoMax = 750.0 },
                new { Nombre = "Batería Interna Laptop", Categoria = "Energía y Fuentes", CostoMin = 300.0, CostoMax = 500.0 },
                new { Nombre = "Cable Adaptador HDMI a VGA", Categoria = "Conectividad", CostoMin = 35.0, CostoMax = 75.0 }
            };

            string[] estadosSolicitud = { "Recibida", "Asignada", "En diagnóstico", "En reparación", "Lista para entregar", "Entregada" };

            // Limpiamos listas globales, colas y reiniciamos la matriz de carga
            DatosGlobales.ListaClientes.Clear();
            DatosGlobales.ListaTecnicos.Clear();
            DatosGlobales.ListaEquipos.Clear();
            DatosGlobales.ListaRepuestos.Clear();
            DatosGlobales.ListaSolicitudes.Clear();
            DatosGlobales.ColaUrgentes.Clear();
            DatosGlobales.ColaNormales.Clear();
            Array.Clear(DatosGlobales.MatrizCargaTecnicos, 0, DatosGlobales.MatrizCargaTecnicos.Length);

            // 1. Generar Clientes con códigos únicos
            for (int i = 0; i < numClientes; i++)
            {
                string codigo = $"CLI-{(i + 1):D3}";
                string nombre = nombres[random.Next(nombres.Length)];
                string apellido = apellidos[random.Next(apellidos.Length)];
                string nombreCompleto = $"{nombre} {apellido}";
                string telefono = $"5{random.Next(1000000, 9999999)}";
                string tipoCliente = tiposClientes[random.Next(tiposClientes.Length)];
                string correo = $"{nombre.ToLower()}.{apellido.ToLower()}@{dominiosCorreo[random.Next(dominiosCorreo.Length)]}";

                Cliente nuevoCliente = new Cliente(codigo, nombreCompleto, telefono, correo, tipoCliente);
                DatosGlobales.ListaClientes.Add(nuevoCliente);
            }

            // 2. Generar Técnicos válidos
            for (int i = 0; i < numTecnicos; i++)
            {
                string codigo = $"TEC-{(i + 1):D3}";
                string nombre = nombres[random.Next(nombres.Length)];
                string apellido = apellidos[random.Next(apellidos.Length)];
                string nombreCompleto = $"{nombre} {apellido}";
                string especialidadElegida = especialidadesDisponibles[random.Next(especialidadesDisponibles.Length)];

                Tecnico nuevoTecnico = new Tecnico()
                {
                    CodigoTecnico = codigo,
                    NombreCompleto = nombreCompleto,
                    Especialidad = especialidadElegida,
                    LimiteTrabajos = 3,
                    TrabajosActivos = 0,
                    ServiciosFinalizados = random.Next(1, 8)
                };
                DatosGlobales.ListaTecnicos.Add(nuevoTecnico);
            }

            // 3. Generar Repuestos
            int repIdx = 1;
            foreach (var repInfo in repuestosBase.Take(numRepuestos))
            {
                int stock = random.Next(2, 10); // Aseguramos stock inicial válido
                int stockMinimo = 3;
                double costo = Math.Round(repInfo.CostoMin + (random.NextDouble() * (repInfo.CostoMax - repInfo.CostoMin)), 2);
                double precioVenta = Math.Round(costo * 1.35, 2);

                Repuesto nuevoRepuesto = new Repuesto($"REP-{repIdx:D3}", repInfo.Nombre, repInfo.Categoria, stock, stockMinimo, costo, precioVenta);
                DatosGlobales.ListaRepuestos.Add(nuevoRepuesto);
                repIdx++;
            }

            // 4. Generar Equipos relacionados a clientes existentes
            for (int i = 0; i < numEquipos; i++)
            {
                string codigo = $"EQP-{(i + 1):D3}";
                string marca = marcas[random.Next(marcas.Length)];
                string numeroSerie = $"SN-{10000 + i}"; // Garantiza series únicas sin colisión
                string estadoFisico = estadosFisicos[random.Next(estadosFisicos.Length)];
                Cliente propietarioAsignado = DatosGlobales.ListaClientes[random.Next(DatosGlobales.ListaClientes.Count)];

                if (i % 3 == 0)
                {
                    ComputadoraPortatil portatil = new ComputadoraPortatil(codigo, numeroSerie, marca, "Inspiron / ProBook", propietarioAsignado, estadoFisico, "Cargador original", true);
                    DatosGlobales.ListaEquipos.Add(portatil);
                }
                else if (i % 3 == 1)
                {
                    ComputadoraEscritorio escritorio = new ComputadoraEscritorio(codigo, numeroSerie, marca, "Desktop Workstation", propietarioAsignado, estadoFisico, "Torre y cables", true);
                    DatosGlobales.ListaEquipos.Add(escritorio);
                }
                else
                {
                    Impresora impresora = new Impresora(codigo, numeroSerie, marca, "EcoTank / LaserJet", propietarioAsignado, estadoFisico, "Cable USB", true);
                    DatosGlobales.ListaEquipos.Add(impresora);
                }
            }

            // 5. Generar Solicitudes respetando restricciones de equipos activos y técnicos
            int solCount = Math.Min(numSolicitudes, numEquipos); // Evitamos saturar más solicitudes que equipos únicos disponibles para prevenir bloqueos
            for (int i = 0; i < solCount; i++)
            {
                string codigo = $"SOL-{(i + 1):D3}";
                Cliente clienteAleatorio = DatosGlobales.ListaClientes[random.Next(DatosGlobales.ListaClientes.Count)];
                Equipo equipoAleatorio = DatosGlobales.ListaEquipos[i]; // Asignación uno a uno por equipo para garantizar equipos sin duplicidad activa

                string problema = problemas[random.Next(problemas.Length)];
                string prioridad = (i % 2 == 0) ? "Urgente" : "Normal";

                Solicitud nuevaSolicitud = new Solicitud(codigo, clienteAleatorio, equipoAleatorio, problema, prioridad);

                // Buscar un técnico compatible y con cupo disponible
                Tecnico tecnicoCompatible = null;
                string tipoEquipo = equipoAleatorio.GetType().Name;

                foreach (var t in DatosGlobales.ListaTecnicos)
                {
                    bool espOk = t.Especialidad == "Todos" || t.Especialidad == "General" || t.Especialidad.Equals(tipoEquipo, StringComparison.OrdinalIgnoreCase) ||
                                 (tipoEquipo.Contains("Portatil") && t.Especialidad.Contains("Portátil")) ||
                                 (tipoEquipo.Contains("Escritorio") && t.Especialidad.Contains("Escritorio")) ||
                                 (tipoEquipo.Contains("Impresora") && t.Especialidad.Contains("Impresora"));

                    if (espOk && t.TrabajosActivos < t.LimiteTrabajos)
                    {
                        tecnicoCompatible = t;
                        break;
                    }
                }

                if (tecnicoCompatible != null)
                {
                    nuevaSolicitud.TecnicoAsignado = tecnicoCompatible;
                    tecnicoCompatible.TrabajosActivos++;

                    // Registrar en la matriz de carga semanal (fila del técnico, día aleatorio de Lunes a Viernes)
                    int indiceTecnico = -1;
                    for (int idx = 0; idx < DatosGlobales.ListaTecnicos.Count; idx++)
                    {
                        if (DatosGlobales.ListaTecnicos[idx].Codigo == tecnicoCompatible.Codigo)
                        {
                            indiceTecnico = idx;
                            break;
                        }
                    }
                    if (indiceTecnico >= 0 && indiceTecnico < 10)
                    {
                        int diaAleatorio = random.Next(0, 5);
                        DatosGlobales.RegistrarAsignacionMatriz(indiceTecnico, diaAleatorio);
                    }

                    nuevaSolicitud.CambiarEstado("Asignada");
                }

                // Agregar a la lista global
                DatosGlobales.ListaSolicitudes.Add(nuevaSolicitud);

                // Encolar obligatoriamente según su prioridad para que el módulo operativo las reconozca
                if (prioridad.Equals("Urgente", StringComparison.OrdinalIgnoreCase))
                {
                    DatosGlobales.ColaUrgentes.Enqueue(nuevaSolicitud);
                }
                else
                {
                    DatosGlobales.ColaNormales.Enqueue(nuevaSolicitud);
                }
            }

            return "Datos de prueba generados exitosamente con validaciones estrictas.";
        }
    }
}