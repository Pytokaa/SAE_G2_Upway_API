using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("estproposesimilaire")]
    public partial class Est_Propose_Similaire
    {
        [Key]
        [Column("idestproposesimilaire")]
        public int IdEstProposeSimilaire { get; set; }
        [Column("idaccessoire")]
        public int IdAccessoire { get; set; }
        [Column("idcommande")]
        public int IdCommande { get; set; }

        //foreign key

        [ForeignKey(nameof(IdAccessoire))]
        [InverseProperty(nameof(Accessoire.LesCommandes))]
        public Accessoire LAccessoire { get; set; } = null!;

        [ForeignKey(nameof(IdCommande))]
        [InverseProperty(nameof(Commande.LesSimilaires))]
        public Commande LaCommande { get; set; } = null!;
    }
}
