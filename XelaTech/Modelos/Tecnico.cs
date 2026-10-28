namespace XelaTech.Modelos
{
    public class Tecnico : Persona
    {
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
            Especialidad = especialidad;
            LimiteTrabajos = 3;
            TrabajosActivos = 0;
            ServiciosFinalizados = anios; // Usando el parámetro de años para servicios finalizados o similar
            Disponibilidad = true;
            CalificacionPromedio = 5.0;
        }
    }
}