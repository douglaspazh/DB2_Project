using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB2_Project.Models
{
    [Table("Productor", Schema = "dbo")]
    [PrimaryKey(nameof(ProductorID))]
    public class Productor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductorID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        
        [Required]
        public string Telefono { get; set; }
        
        public string? Email { get; set; }
        
        public string? Estado { get; set; }

        public DateOnly FechaRegistro { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
