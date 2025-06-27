using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB2_Project.Models
{
    public class Finca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FincaID { get; set; }

        [ForeignKey("Productor")]
        public int ProductorID { get; set; }
        public Productor Productor { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        public string? Ubicacion { get; set; }

        [Required]
        public decimal ExtensionTotal { get; set; }
    }
}
