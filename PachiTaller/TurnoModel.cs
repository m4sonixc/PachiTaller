using SQLite;

namespace PachiTaller
{
    [Table("Turnos")]
    public class TurnoModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string NombreCliente { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Vehiculo { get; set; } = string.Empty;
        public string Motivo { get; set; } = string.Empty;
        public string FechaTurno { get; set; } = string.Empty;
        public string Estado { get; set; } = "Pendiente";

        public string FechaEstimadaTermino { get; set; } = "Sin definir";
        public string Diagnostico { get; set; } = "Pendiente de revisión en taller";

        // --- Nuevos campos de Costos y Repuestos ---
        public decimal CostoManoObra { get; set; } = 0;
        public decimal CostoRepuestos { get; set; } = 0;
        public decimal CostoTotal => CostoManoObra + CostoRepuestos; // Cálculo automático
    }
}