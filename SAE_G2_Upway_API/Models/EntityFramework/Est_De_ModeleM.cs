using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("t_j_estdemodelem_edmdlm")]
    public partial class Est_De_ModeleM
    {
        //Les colonnes
        [Key]
        [Column("edmdlm_id")]
        public int EstDeModeleM { get; set; }
        [Column("mtr_id")]
        public int IdMoteur { get; set; }
        [Column("mdl_id")]
        public int IdModele { get; set; }

        //relation avec la table modele
        [ForeignKey(nameof(IdModele))]
        [InverseProperty(nameof(Modele.LesMoteurs))]
        public virtual Modele LeModele { get; set; } = null!;
        
        //relation avec la table moteur
        [ForeignKey(nameof(IdMoteur))]
        [InverseProperty(nameof(Moteur.LesModeles))]
        public virtual Moteur LeMoteur { get; set; } = null!;
    }
}
