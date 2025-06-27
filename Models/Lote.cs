using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB2_Project.Models
{
    [Table("Lote", Schema = "dbo")]
    public class Lote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LoteID { get; set; }

        [Required]
        [ForeignKey("Finca")]
        public int FincaID { get; set; }
        public Finca Finca { get; set; }

        [Required]
        public string UnidadMedida { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal Extension { get; set; }

        [Required]
        public int MaximoCosechas { get; set; }

        [Required]
        [MaxLength(100)]
        public string TipoSuelo { get; set; }

        [Required]
        [MaxLength(100)]
        public string TipoRiego { get; set; }
    }
}
