using System;
using System.Collections.Generic;
using System.ComponentModel; // Necesario para BindingList
using XelaTech.Modelos;

namespace XelaTech
{
    public static class DatosGlobales
    {
        // Listas globales de entidades actualizadas a BindingList para sincronización automática
        public static BindingList<Solicitud> ListaSolicitudes = new BindingList<Solicitud>();
        public static BindingList<Cliente> ListaClientes = new BindingList<Cliente>();
        public static BindingList<Tecnico> ListaTecnicos = new BindingList<Tecnico>();
        public static BindingList<Equipo> ListaEquipos = new BindingList<Equipo>();
        public static BindingList<Repuesto> ListaRepuestos = new BindingList<Repuesto>();

        // Colas separadas por prioridad
        public static Queue<Solicitud> ColaUrgentes = new Queue<Solicitud>();
        public static Queue<Solicitud> ColaNormales = new Queue<Solicitud>();

        // =====================================================================
        // MATRIZ NUMÉRICA REAL DE CARGA SEMANAL (PUNTO 7)
        // Filas: Hasta 10 técnicos, Columnas: 5 días hábiles (Lunes a Viernes)
        // =====================================================================
        public static int[,] MatrizCargaTecnicos = new int[10, 5];
        public static string[] DiasSemana = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };

        /// <summary>
        /// Registra una asignación real incrementando el contador en la celda del técnico y día correspondiente.
        /// </summary>
        public static void RegistrarAsignacionMatriz(int indiceTecnico, int diaSemana)
        {
            if (indiceTecnico >= 0 && indiceTecnico < 10 && diaSemana >= 0 && diaSemana < 5)
            {
                MatrizCargaTecnicos[indiceTecnico, diaSemana]++;
            }
        }

        /// <summary>
        /// Calcula y retorna el técnico con mayor carga acumulada en la semana.
        /// </summary>
        public static string ObtenerTecnicoConMayorCarga()
        {
            if (ListaTecnicos == null || ListaTecnicos.Count == 0) return "No hay técnicos registrados";

            int maxCarga = -1;
            string nombreTecnicoTop = "Ninguno";

            for (int i = 0; i < ListaTecnicos.Count && i < 10; i++)
            {
                int cargaAcumulada = 0;
                for (int j = 0; j < 5; j++)
                {
                    cargaAcumulada += MatrizCargaTecnicos[i, j];
                }

                if (cargaAcumulada > maxCarga)
                {
                    maxCarga = cargaAcumulada;
                    nombreTecnicoTop = $"{ListaTecnicos[i].NombreCompleto} (Total: {maxCarga} asignaciones)";
                }
            }

            return nombreTecnicoTop;
        }

        // =====================================================================
        // BÚSQUEDAS SECUENCIALES MANUALES (PUNTO 9)
        // =====================================================================

        /// <summary>
        /// 1. Clientes: Búsqueda secuencial manual por una parte del nombre (Ignora mayúsculas/minúsculas).
        /// </summary>
        public static List<Cliente> BuscarClientesPorNombreSecuencial(string textoBuscado)
        {
            List<Cliente> resultados = new List<Cliente>();
            if (string.IsNullOrWhiteSpace(textoBuscado)) return resultados;

            foreach (var c in ListaClientes)
            {
                if (c.NombreCompleto != null && c.NombreCompleto.IndexOf(textoBuscado, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    resultados.Add(c);
                }
            }
            return resultados;
        }

        /// <summary>
        /// 2. Equipos: Búsqueda secuencial manual por marca (Ignora mayúsculas/minúsculas).
        /// </summary>
        public static List<Equipo> BuscarEquiposPorMarcaSecuencial(string marcaBuscada)
        {
            List<Equipo> resultados = new List<Equipo>();
            if (string.IsNullOrWhiteSpace(marcaBuscada)) return resultados;

            foreach (var eq in ListaEquipos)
            {
                if (eq.Marca != null && eq.Marca.IndexOf(marcaBuscada, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    resultados.Add(eq);
                }
            }
            return resultados;
        }

        /// <summary>
        /// 3. Solicitudes: Búsqueda secuencial manual por estado (Devuelve todas las coincidencias).
        /// </summary>
        public static List<Solicitud> BuscarSolicitudPorEstadoSecuencial(string estadoBuscado)
        {
            List<Solicitud> resultados = new List<Solicitud>();
            if (string.IsNullOrWhiteSpace(estadoBuscado)) return resultados;

            foreach (var s in ListaSolicitudes)
            {
                if (s.Estado != null && s.Estado.IndexOf(estadoBuscado, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    resultados.Add(s);
                }
            }

            return resultados;
        }

        // =====================================================================
        // ORDENAMIENTOS MANUALES (PUNTO 8)
        // =====================================================================

        // Bubble Sort: Ordenar solicitudes por costo total
        public static void OrdenarSolicitudesPorCostoBubbleSort(List<Solicitud> lista)
        {
            int n = lista.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (lista[j].Total > lista[j + 1].Total)
                    {
                        var temp = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temp;
                    }
                }
            }
        }

        // Insertion Sort: Ordenar técnicos por servicios de soporte
        public static void OrdenarTecnicosPorServiciosInsertionSort(List<Tecnico> lista)
        {
            int n = lista.Count;
            for (int i = 1; i < n; ++i)
            {
                var key = lista[i];
                int j = i - 1;

                while (j >= 0 && lista[j].ServiciosFinalizados > key.ServiciosFinalizados)
                {
                    lista[j + 1] = lista[j];
                    j = j - 1;
                }
                lista[j + 1] = key;
            }
        }

        // Selection Sort: Ordenar técnicos por servicios finalizados
        public static void OrdenarTecnicosPorServiciosSelectionSort(List<Tecnico> lista)
        {
            int n = lista.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (lista[j].ServiciosFinalizados < lista[minIndex].ServiciosFinalizados)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    var temp = lista[i];
                    lista[i] = lista[minIndex];
                    lista[minIndex] = temp;
                }
            }
        }

        // Shell Sort: Ordenar repuestos por existencias (cantidad disponible)
        public static void OrdenarRepuestosPorExistenciasShellSort(List<Repuesto> lista)
        {
            int n = lista.Count;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    var temp = lista[i];
                    int j;
                    for (j = i; j >= gap && lista[j - gap].CantidadDisponible > temp.CantidadDisponible; j -= gap)
                    {
                        lista[j] = lista[j - gap];
                    }
                    lista[j] = temp;
                }
            }
        }
    }
}