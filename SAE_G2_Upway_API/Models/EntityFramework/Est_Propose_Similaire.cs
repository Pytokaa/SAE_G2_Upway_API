using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("estproposesimilaire")]
    public partial class Est_Propose_Similaire
    {
        [Key]
        [Column("idestproposesimilaire", TypeName="integer")]
        public int IdEstProposeSimilaire { get; set; }
        [Column("idaccessoire")]
        public int IdAccessoire { get; set; }
        [Column("idcommande")]
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
