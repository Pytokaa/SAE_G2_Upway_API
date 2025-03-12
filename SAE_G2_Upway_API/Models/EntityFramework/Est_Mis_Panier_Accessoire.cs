using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("est_mis_panier_accessoire")]
    public partial class Est_Mis_Panier_Accessoire
    {
        [Key]
        [Column("idpanieraccessoire")]
        public int IdEstProposeSimilaire { get; set; }
        [Column("idaccessoire")]
        public int IdAccessoire { get; set; }
        [Column("idcommande")]
        public int IdCommande { get; set; }

        //foreign key

        [ForeignKey(nameof(IdAccessoire))]
        [InverseProperty(nameof(Accessoire.LesCommandesAccessoire))]
        public virtual Accessoire LAccessoire { get; set; } = null!;

        [ForeignKey(nameof(IdCommande))]
        [InverseProperty(nameof(Commande.LesAccessoires))]
        public virtual Commande LaCommande { get; set; } = null!;
    }
}
