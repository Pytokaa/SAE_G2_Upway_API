using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("estdemodelem")]
    public partial class Est_De_ModeleM
    {
        //Les colonnes
        [Key]
        [Column("idestdemodelem")]
        public int EstDeModeleM { get; set; }
        [Column("idmoteur")]
        public int IdMoteur { get; set; }
        [Column("idmodele")]
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
