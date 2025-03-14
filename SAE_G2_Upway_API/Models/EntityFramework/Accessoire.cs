using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


// il faut ajouter encore les liens vers les autres tables lorsqu'elle seront créées
namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("t_e_accessoire_acce")]
public partial class Accessoire
{
    [Key]
    [Column("acce_id")] 
    public int IdAccessoire { get; set; }
    
    [Column("pdt_id")]
    public int IdProduit { get; set; }
    [Column("cata_id")]
    public int IdCatA { get; set; }
    
    [Column("acce_date")]
    public DateTime DateAccessoire { get; set; }

    
    //relation avec la table Produit
    
    [ForeignKey(nameof(IdProduit))]
    
    [InverseProperty(nameof(Produit.Accessoire))]
    public Produit Produit { get; set; } = null!;
    
    
    //relation avec la table CategorieAccessoire
    [ForeignKey(nameof(IdCatA))]
    public CategorieAccessoire CategorieAccessoire { get; set; } = null!;
    
    //relation avec la table est_propose_similaire

    [InverseProperty(nameof(Est_Propose_Similaire.LAccessoire))]
    public virtual ICollection<Est_Propose_Similaire> LesCommandes { get; set; } = new List<Est_Propose_Similaire>();

    //relation avec la table est_mis_panier_accessoire
    [InverseProperty(nameof(Est_Mis_Panier_Accessoire.LAccessoire))]
    public virtual ICollection<Est_Mis_Panier_Accessoire> LesCommandesAccessoire { get; set; } = new List<Est_Mis_Panier_Accessoire>();

}