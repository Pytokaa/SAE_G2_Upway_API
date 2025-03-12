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
    
    //relation avec la table Produit
    
    [ForeignKey("idproduit")]
    public int ProduitId { get; set; }

    public Produit Produit { get; set; }
    
    
    //relation avec la table produit
    public int CategorieAccessoireId { get; set; }
    
    [ForeignKey(nameof(CategorieAccessoireId))]
    public CategorieAccessoire CategorieAccessoire { get; set; }
    
    [Column("dateaccessoire")]
    public DateTime DateAccessoire { get; set; }

    [InverseProperty(nameof(Est_Propose_Similaire.LAccessoire))]
    public virtual ICollection<Est_Propose_Similaire> LesCommandes { get; set; } = new List<Est_Propose_Similaire>();

    [InverseProperty(nameof(Est_Mis_Panier_Accessoire.LAccessoire))]
    public virtual ICollection<Est_Mis_Panier_Accessoire> LesCommandesAccessoire { get; set; } = new List<Est_Mis_Panier_Accessoire>();

}