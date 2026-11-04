using System;

namespace XelaTech.Modelos
{
    public abstract class Equipo
    {
        public string CodigoEquipo { get; set; }

        public string CodigoInterno
        {
            get => CodigoEquipo;
            set => CodigoEquipo = value;
        }

        public string NumeroDeSerie { get; set; }

        public string NumeroSerie
        {
            get => NumeroDeSerie;
            set => NumeroDeSerie = value;
        }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public Cliente Propietario { get; set; }
        public string EstadoFisico { get; set; }
        public string AccesoriosEntregados { get; set; }
        public string TipoEquipo { get; set; }

        // Propiedad agregada para que el DataGridView genere automáticamente la columna del costo polimórfico
        public double CostoRevision => CalcularCostoRevision();

        public Equipo(string codigoEquipo, string numeroDeSerie, string marca, string modelo, Cliente propietario, string estadoFisico, string accesoriosEntregados, string tipoEquipo)
        {
            CodigoEquipo = codigoEquipo;
            NumeroDeSerie = numeroDeSerie;
            Marca = marca;
            Modelo = modelo;
            Propietario = propietario;
            EstadoFisico = estadoFisico;
            AccesoriosEntregados = accesoriosEntregados;
            TipoEquipo = tipoEquipo;
        }

        public virtual double CalcularCostoRevision()
        {
            return 50.00;
        }

        public virtual string ObtenerDetalleEquipo()
        {
            return $"[{CodigoEquipo}] {Marca} {Modelo} - Serie: {NumeroDeSerie} | Propietario: {(Propietario != null ? Propietario.NombreCompleto : "Sin asignar")}";
        }

        public override string ToString()
        {
            return $"{Marca} {Modelo} (Serie: {NumeroDeSerie})";
        }
    }
}