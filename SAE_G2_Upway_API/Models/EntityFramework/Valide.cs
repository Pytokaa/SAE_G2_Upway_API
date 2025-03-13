using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("t_j_valide_val")]
    public partial class Valide
    {
        //Colonne
        [Key]
        [Column("val_id")]
        public int IdValide { get; set; }
        [Column("rapinsp_id")]
        public int IdRapport { get; set; }
        [Column("typ_id")]
        public int IdType { get; set; }

        //Relation avec la table Rapport
        [ForeignKey(nameof(IdRapport))]
        [InverseProperty(nameof(RapportInspection.LesTypes))]
        public virtual RapportInspection LeRapport { get; set; } = null!;

        //Relation avec la table Type
        [ForeignKey(nameof(IdType))]
        [InverseProperty(nameof(Type.LesRapports))]
        public virtual Type LeType { get; set; } = null!;
    }
}
