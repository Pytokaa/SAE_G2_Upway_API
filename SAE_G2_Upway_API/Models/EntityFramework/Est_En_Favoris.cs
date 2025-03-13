using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("t_j_estenfavoris_eefav")]
    public partial class Est_En_Favoris
    {
        //Colonnes
        [Key]
        [Column("eefav_id")]
        public int IdEstEnFavoris { get; set; }
        [Column("clt_id")]
        public int IdClient { get; set; }
        [Column("pdt_id")]
        public int IdProduit { get; set; }

        //relation avec la table client
        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.LesFavoris))]
        public virtual Client ClientFavoris { get; set; } = null!;
        
        
        //relation avec la table client 
        [ForeignKey(nameof(IdProduit))]
        [InverseProperty(nameof(Produit.DansLesFavoris))]
        public virtual Produit LesProduits { get; set; } = null!;
    }
}
