using System;
using XelaTech.Modelos;

namespace XelaTech
{
    public static class GeneradorDatos
    {
        public static void CargarDatosIniciales()
        {
            // Evitar generar los mismos datos más de una vez
            if (DatosGlobales.ListaClientes.Count > 0)
            {
                return;
            }

            // 1. Clientes
            Cliente c1 = new Cliente(
                "CLI-001", "Carlos Gómez", "1234567890101",
                "5555-0101", "Zona 1, Quetzaltenango");

            Cliente c2 = new Cliente(
                "CLI-002", "María López", "9876543210101",
                "5555-0202", "Zona 3, Quetzaltenango");

            Cliente c3 = new Cliente(
                "CLI-003", "Juan Pérez", "5544332210101",
                "5555-0303", "Zona 9, Quetzaltenango");

            DatosGlobales.ListaClientes.Add(c1);
            DatosGlobales.ListaClientes.Add(c2);
            DatosGlobales.ListaClientes.Add(c3);

            // 2. Técnicos
            Tecnico t1 = new Tecnico(
                "TEC-001", "Pedro Ramírez", "1122334450101",
                "4444-0101", "Quetzaltenango", "Hardware", 5);

            Tecnico t2 = new Tecnico(
                "TEC-002", "Ana Martínez", "6677889900101",
                "4444-0202", "Quetzaltenango", "Redes", 3);

            DatosGlobales.ListaTecnicos.Add(t1);
            DatosGlobales.ListaTecnicos.Add(t2);

            // 3. Equipos (Instanciando mediante Clases Derivadas por Polimorfismo)
            ComputadoraPortatil eq1 = new ComputadoraPortatil(
                "EQ-001", "SN-99812", "Dell", "XPS 15",
                c1, "Bueno", "Cargador original", true);

            ComputadoraEscritorio eq2 = new ComputadoraEscritorio(
                "EQ-002", "SN-44120", "HP", "Pavilion",
                c2, "Bueno", "Cable de poder", false);

            Impresora eq3 = new Impresora(
                "EQ-003", "SN-33119", "Epson", "L3150",
                c3, "Bueno", "Cable USB", "Cartucho/Tóner");

            DatosGlobales.ListaEquipos.Add(eq1);
            DatosGlobales.ListaEquipos.Add(eq2);
            DatosGlobales.ListaEquipos.Add(eq3);

            // 4. Repuestos
            Repuesto r1 = new Repuesto(
                "REP-001", "Memoria RAM", "Hardware", 10, 3, 150, 200);

            Repuesto r2 = new Repuesto(
                "REP-002", "Disco SSD", "Almacenamiento", 8, 2, 250, 325);

            Repuesto r3 = new Repuesto(
                "REP-003", "Cable USB", "Accesorios", 15, 5, 20, 35);

            DatosGlobales.ListaRepuestos.Add(r1);
            DatosGlobales.ListaRepuestos.Add(r2);
            DatosGlobales.ListaRepuestos.Add(r3);

            // 5. Solicitudes
            Solicitud s1 = new Solicitud(
                "SOL-001", c1, eq1,
                "Laptop no enciende", "Urgente");

            s1.CostoManoObra = 250;
            s1.TecnicoAsignado = t1;

            Solicitud s2 = new Solicitud(
                "SOL-002", c2, eq2,
                "Mantenimiento preventivo", "Normal");

            s2.CostoManoObra = 150;
            s2.TecnicoAsignado = t2;

            Solicitud s3 = new Solicitud(
                "SOL-003", c3, eq3,
                "Impresora no imprime", "Urgente");

            s3.CostoManoObra = 350;
            s3.TecnicoAsignado = t1;

            DatosGlobales.ListaSolicitudes.Add(s1);
            DatosGlobales.ListaSolicitudes.Add(s2);
            DatosGlobales.ListaSolicitudes.Add(s3);

            // 6. Colas de prioridad
            DatosGlobales.ColaUrgentes.Enqueue(s1);
            DatosGlobales.ColaUrgentes.Enqueue(s3);

            DatosGlobales.ColaNormales.Enqueue(s2);

            // 7. Matriz de carga semanal
            DatosGlobales.MatrizCargaSemanal[0, 0] = 2;
            DatosGlobales.MatrizCargaSemanal[0, 1] = 4;
            DatosGlobales.MatrizCargaSemanal[1, 0] = 1;
            DatosGlobales.MatrizCargaSemanal[1, 2] = 3;
        }
    }
}