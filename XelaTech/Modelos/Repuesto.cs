namespace XelaTech.Modelos
{
    public class Repuesto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Existencia { get; set; }
        public int ExistenciaMinima { get; set; }
        public double CostoUnitario { get; set; }
        public double PrecioVenta { get; set; }
        public int CantidadUtilizada { get; set; }

        public Repuesto(string codigo, string nombre, string categoria, int existencia, int minima, double costo, double precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Categoria = categoria;
            Existencia = existencia;
            ExistenciaMinima = minima;
            CostoUnitario = costo;
            PrecioVenta = precio;
            CantidadUtilizada = 0;
        }
    }
}