using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("valide")]
    public partial class Valide
    {
        [Key]
        [Column("idvalide")]
        public int IdValide { get; set; }
        [Column("idrapport")]
        public int IdRapport { get; set; }
        [Column("idtype")]
        public int IdType { get; set; }

        [ForeignKey(nameof(IdRapport))]
        public RapportInspection LeRapport { get; set; } = null!;

        [ForeignKey(nameof(IdType))]
        public Type LeType { get; set; } = null!;
    }
}
