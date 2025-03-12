using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("estcompose")]
    public partial class Est_Compose
    {
        // Colonnes
        [Key]
        [Column("idcompose")]
        public int IdCompose { get; set; }
        [Column("idvelo")]
        public int IdVelo { get; set; }
        [Column("idmoteur")]
        public int IdMoteur { get; set; }

        //Foreign Key
        [ForeignKey(nameof(IdVelo))]
        [InverseProperty(nameof(Velo.LesMoteurs))]
        public virtual Velo LeVelo { get; set; } = null!;

        [ForeignKey(nameof(IdMoteur))]
        [InverseProperty(nameof(Moteur.LesVelos))]
        public virtual Moteur LeMoteur { get; set; } = null!;
    }
}
