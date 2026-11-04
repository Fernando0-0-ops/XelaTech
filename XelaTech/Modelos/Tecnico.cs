namespace XelaTech.Modelos
{
    public class Tecnico : Persona
    {
        // Propiedad que faltaba para que los reportes la reconozcan sin errores
        public string CodigoTecnico { get; set; }

        public string Especialidad { get; set; }
        public bool Disponibilidad { get; set; }
        public int TrabajosActivos { get; set; }
        public int LimiteTrabajos { get; set; }
        public int ServiciosFinalizados { get; set; }
        public double CalificacionPromedio { get; set; }

        // Constructor con los parámetros completos
        public Tecnico(string codigo, string nombreCompleto, string telefono, string correo, string especialidad, int limiteTrabajos = 3)
            : base(codigo, nombreCompleto, telefono, correo)
        {
            CodigoTecnico = codigo;
            Especialidad = especialidad;
            LimiteTrabajos = limiteTrabajos;
            TrabajosActivos = 0;
            ServiciosFinalizados = 0;
            Disponibilidad = true;
            CalificacionPromedio = 5.0;
        }

        // Sobrecarga por si se llama con 7 argumentos
        public Tecnico(string codigo, string nombreCompleto, string telefono, string correo, string direccionExtra, string especialidad, int anios)
            : base(codigo, nombreCompleto, telefono, correo)
        {
            CodigoTecnico = codigo;
            Especialidad = especialidad;
            LimiteTrabajos = 3;
            TrabajosActivos = 0;
            ServiciosFinalizados = anios;
            Disponibilidad = true;
            CalificacionPromedio = 5.0;
        }

        // Constructor vacío que inicializa correctamente la clase base Persona
        public Tecnico() : base("S/C", "Sin Nombre", "0000-0000", "correo@example.com")
        {
            CodigoTecnico = "S/C";
            Especialidad = "General";
            LimiteTrabajos = 3;
            TrabajosActivos = 0;
            ServiciosFinalizados = 0;
            Disponibilidad = true;
            CalificacionPromedio = 5.0;
        }
    }
}