using System;
using System.Collections.Generic;
using XelaTech.Modelos;

namespace XelaTech
{
    public static class DatosGlobales
    {
        // 1. Listas Obligatorias (List<T>)
        public static List<Cliente> ListaClientes = new List<Cliente>();
        public static List<Tecnico> ListaTecnicos = new List<Tecnico>();
        public static List<Equipo> ListaEquipos = new List<Equipo>();
        public static List<Solicitud> ListaSolicitudes = new List<Solicitud>();
        public static List<Repuesto> ListaRepuestos = new List<Repuesto>();
        public static List<double> CalificacionesAtencion = new List<double>();


        // 2. Colas Obligatorias (Queue<T>) para Prioridades
        public static Queue<Solicitud> ColaUrgentes = new Queue<Solicitud>();
        public static Queue<Solicitud> ColaNormales = new Queue<Solicitud>();

        // 3. Arreglo Unidimensional para Calificaciones (1 a 5 estrellas)
        public static int[] ConteoCalificaciones = new int[5]; // Índices 0 al 4 representan de 1 a 5 estrellas

        // 4. Arreglo Multidimensional (Matriz) para Carga Semanal de Técnicos (Filas: Técnicos, Columnas: 5 Días Lunes-Viernes)
        public static int[,] MatrizCargaSemanal = new int[10, 5];

        // ==========================================
        // MÉTODOS DE ORDENAMIENTO MANUALES (Sin Sort / OrderBy)
        // ==========================================

        // Bubble Sort para ordenar Solicitudes por Costo Total (Ascendente o Descendente)
        public static void BubbleSortSolicitudesPorCosto(bool ascendente = true)
        {
            int n = ListaSolicitudes.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    bool condicion = ascendente ?
                        ListaSolicitudes[j].Total > ListaSolicitudes[j + 1].Total :
                        ListaSolicitudes[j].Total < ListaSolicitudes[j + 1].Total;

                    if (condicion)
                    {
                        var temp = ListaSolicitudes[j];
                        ListaSolicitudes[j] = ListaSolicitudes[j + 1];
                        ListaSolicitudes[j + 1] = temp;
                    }
                }
            }
        }

        // Selection Sort para ordenar Técnicos por Servicios Finalizados
        public static void SelectionSortTecnicosPorServicios(bool ascendente = false)
        {
            int n = ListaTecnicos.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minMaxIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    bool condicion = ascendente ?
                        ListaTecnicos[j].ServiciosFinalizados < ListaTecnicos[minMaxIndex].ServiciosFinalizados :
                        ListaTecnicos[j].ServiciosFinalizados > ListaTecnicos[minMaxIndex].ServiciosFinalizados;

                    if (condicion)
                    {
                        minMaxIndex = j;
                    }
                }
                if (minMaxIndex != i)
                {
                    var temp = ListaTecnicos[i];
                    ListaTecnicos[i] = ListaTecnicos[minMaxIndex];
                    ListaTecnicos[minMaxIndex] = temp;
                }
            }
        }

        // ==========================================
        // MÉTODOS DE BÚSQUEDA MANUALES (Sin BinarySearch)
        // ==========================================

        // Búsqueda Secuencial (Ej: Buscar Clientes por nombre parcial)
        public static List<Cliente> BusquedaSecuencialClientes(string filtro)
        {
            List<Cliente> resultados = new List<Cliente>();
            foreach (var c in ListaClientes)
            {
                if (c.NombreCompleto.ToLower().Contains(filtro.ToLower()) || c.Codigo.ToLower().Contains(filtro.ToLower()))
                {
                    resultados.Add(c);
                }
            }
            return resultados;
        }

        // Búsqueda Binaria Manual por Código de Solicitud (Requiere la lista ordenada previamente por Código)
        public static Solicitud BusquedaBinariaSolicitud(string codigoBuscado)
        {
            // Primero aseguramos ordenamiento básico por código para que funcione la binaria
            ListaSolicitudes.Sort((s1, s2) => string.Compare(s1.CodigoSolicitud, s2.CodigoSolicitud));

            int izquierda = 0;
            int derecha = ListaSolicitudes.Count - 1;

            while (izquierda <= derecha)
            {
                int medio = izquierda + (derecha - izquierda) / 2;
                int comparacion = string.Compare(ListaSolicitudes[medio].CodigoSolicitud, codigoBuscado, StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0)
                    return ListaSolicitudes[medio];

                if (comparacion < 0)
                    izquierda = medio + 1;
                else
                    derecha = medio - 1;
            }

            return null; // No encontrado
        }

        // ==========================================
        // GENERADOR DE DATOS DE PRUEBA CON RANDOM
        // ==========================================
        public static void GenerarDatosPrueba()
        {
            Random rand = new Random();

            // 1. Crear Técnicos de Prueba
            if (ListaTecnicos.Count == 0)
            {
                ListaTecnicos.Add(new Tecnico("TEC-01", "Carlos Pérez", "5512-3456", "carlos@xelatech.com", "Computadora Portátil", 3));
                ListaTecnicos.Add(new Tecnico("TEC-02", "Ana Gómez", "5598-7654", "ana@xelatech.com", "Computadora Escritorio", 3));
                ListaTecnicos.Add(new Tecnico("TEC-03", "Mario López", "5543-2109", "mario@xelatech.com", "Impresora", 2));
            }

            // 2. Crear Clientes de Prueba
            if (ListaClientes.Count == 0)
            {
                ListaClientes.Add(new Cliente("CLI-01", "Juan Fuentes", "4411-2233", "juan@gmail.com", "Estudiante"));
                ListaClientes.Add(new Cliente("CLI-02", "María Rodas", "4422-3344", "maria@empresa.gt", "Profesional"));
            }

            // 3. Crear Repuestos de Prueba
            if (ListaRepuestos.Count == 0)
            {
                ListaRepuestos.Add(new Repuesto("REP-01", "Cargador Universal Laptop", "Accesorios", 10, 2, 120.00, 175.00));
                ListaRepuestos.Add(new Repuesto("REP-02", "Tóner Negro HP", "Impresión", 5, 1, 250.00, 350.00));
                ListaRepuestos.Add(new Repuesto("REP-03", "Pasta Térmica Alta Gama", "Mantenimiento", 15, 3, 45.00, 75.00));
            }
        }
    }
}