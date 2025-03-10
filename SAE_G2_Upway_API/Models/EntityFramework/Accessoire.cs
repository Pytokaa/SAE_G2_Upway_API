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
    
    [ForeignKey("idproduit")]
    public int ProduitId { get; set; }

    public Produit Produit { get; set; }
    
    
    //relation avec la table produit
    public int CategorieAccessoireId { get; set; }
    
    [ForeignKey(nameof(CategorieAccessoireId))]
    public CategorieAccessoire CategorieAccessoire { get; set; }
    
}