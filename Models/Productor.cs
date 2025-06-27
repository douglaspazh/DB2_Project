using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB2_Project.Models
{
    [Table("Productor", Schema = "dbo")]
    public class Productor
    {
        public int ProductorID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        public string Direccion { get; set; }
        
        [Required]
        public string Telefono { get; set; }
        
        public string? Email { get; set; }
        
        public string? Estado { get; set; }

        public DateOnly FechaRegistro { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
