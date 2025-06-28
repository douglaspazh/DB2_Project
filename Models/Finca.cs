using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB2_Project.Models
{
    [Table("Finca", Schema = "dbo")]
    [PrimaryKey("FincaID")]
    public class Finca
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FincaID { get; set; }

        [ForeignKey("Productor")]
        public int ProductorID { get; set; }
        public Productor? Productor { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        public string? Direccion { get; set; }

        [Required]
        [Precision(10, 2)]
        public decimal ExtensionTotal { get; set; }

        public DateOnly FechaRegistro { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
