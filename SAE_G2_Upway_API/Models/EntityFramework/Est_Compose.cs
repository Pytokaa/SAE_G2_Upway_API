using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("t_j_estcompose_estcomp")]
    public partial class Est_Compose
    {
        // Colonnes
        [Key]
        [Column("estcomp_id")]
        public int IdCompose { get; set; }
        [Column("vel_id")]
        public int IdVelo { get; set; }
        [Column("mtr_id")]
        public int IdMoteur { get; set; }

        //relation avec la table velo
        [ForeignKey(nameof(IdVelo))]
        [InverseProperty(nameof(Velo.LesMoteurs))]
        public virtual Velo LeVelo { get; set; } = null!;

        
        //relation avec la table moteur
        [ForeignKey(nameof(IdMoteur))]
        [InverseProperty(nameof(Moteur.LesVelos))]
        public virtual Moteur LeMoteur { get; set; } = null!;
    }
}
