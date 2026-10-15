using SQLite;

namespace PachiTaller
{
    [Table("Repuestos")]
    public class RepuestoModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;       // Ej: "Aceite Sintético 10W40 4L"
        public string Categoria { get; set; } = "General";        // Ej: "Lubricantes", "Frenos", "Filtros"
        public int Stock { get; set; } = 0;                      // Cantidad disponible
        public decimal Precio { get; set; } = 0;                 // Precio unitario
    }
}