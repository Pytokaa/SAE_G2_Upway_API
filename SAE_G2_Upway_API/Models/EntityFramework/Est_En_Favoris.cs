using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework
{
    [Table("estenfavoris")]
    public partial class Est_En_Favoris
    {
        //Colonnes
        [Key]
        [Column("idestenfavoris")]
        public int IdEstEnFavoris { get; set; }
        [Column("idclient")]
        public int IdClient { get; set; }
        [Column("idproduit")]
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
