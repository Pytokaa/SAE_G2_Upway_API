using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("t_j_estmispanieraccessoire_empanacc")]
    public partial class Est_Mis_Panier_Accessoire
    {
        [Key]
        [Column("empanacc_id")]
        public int IdEstProposeSimilaire { get; set; }
        [Column("acce_id")]
        public int IdAccessoire { get; set; }
        [Column("comm_id")]
        public int IdCommande { get; set; }
        [Column("empanacc_quantite")]
        public int Quantite { get; set; }

        //foreign key

        [ForeignKey(nameof(IdAccessoire))]
        [InverseProperty(nameof(Accessoire.LesCommandesAccessoire))]
        public virtual Accessoire LAccessoire { get; set; } = null!;

        [ForeignKey(nameof(IdCommande))]
        [InverseProperty(nameof(Commande.LesAccessoires))]
        public virtual Commande LaCommande { get; set; } = null!;
    }
}
