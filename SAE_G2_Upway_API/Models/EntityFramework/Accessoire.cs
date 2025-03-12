using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


// il faut ajouter encore les liens vers les autres tables lorsqu'elle seront créées
namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("accessoire")]
public partial class Accessoire
{
    [Key]
    [Column("idaccessoire")] 
    public int IdAccessoire { get; set; }
    
    [Column("idproduit")]
    public int IdProduit { get; set; }
    [Column("idcatA")]
    public int IdCatA { get; set; }
    
    [Column("dateaccessoire")]
    public DateTime DateAccessoire { get; set; }

    
    //relation avec la table Produit
    
    [ForeignKey(nameof(IdProduit))]
    public Produit Produit { get; set; } = null!;
    
    
    //relation avec la table CategorieAccessoire
    [ForeignKey(nameof(IdCatA))]
    public CategorieAccessoire? CategorieAccessoire { get; set; }
    
    //relation avec la table est_propose_similaire

    [InverseProperty(nameof(Est_Propose_Similaire.LAccessoire))]
    public virtual ICollection<Est_Propose_Similaire> LesCommandes { get; set; } = new List<Est_Propose_Similaire>();

    //relation avec la table est_mis_panier_accessoire
    [InverseProperty(nameof(Est_Mis_Panier_Accessoire.LAccessoire))]
    public virtual ICollection<Est_Mis_Panier_Accessoire> LesCommandesAccessoire { get; set; } = new List<Est_Mis_Panier_Accessoire>();

}