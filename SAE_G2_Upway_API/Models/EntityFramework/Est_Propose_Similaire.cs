using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("t_j_estproposesimilaire_estpropsim")]
    public partial class Est_Propose_Similaire
    {
        [Key]
        [Column("estpropsim_id")]
        public int IdEstProposeSimilaire { get; set; }
        [Column("acce_id")]
        public int IdAccessoire { get; set; }
        [Column("comm_id")]
        public int IdCommande { get; set; }

        //relation avec la table accessoire

        [ForeignKey(nameof(IdAccessoire))]
        [InverseProperty(nameof(Accessoire.LesCommandes))]
        public virtual Accessoire LAccessoire { get; set; } = null!;

        //relation avec la table commande
        [ForeignKey(nameof(IdCommande))]
        [InverseProperty(nameof(Commande.LesSimilaires))]
        public virtual Commande LaCommande { get; set; } = null!;
    }
}
