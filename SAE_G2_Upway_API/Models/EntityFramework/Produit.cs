


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



//il faut encore ajouter les id pour les photos et les marques

namespace SAE_G2_Upway_API.Models.EntityFramework;
[Table("produit")]
public partial class Produit
{
    [Key]
    [Column("idproduit")]
    public int Idproduit { get; set; }
    
    
    [Column("nomproduit")]
    [StringLength(100)]
    public string Nomproduit { get; set; }
    
    
    [Column("prixproduit")]
    public double Prixproduit { get; set; }
    
    [Column("descriptionproduit")]
    [StringLength(200)]
    public string Descriptionproduit { get; set; }
    
    [Column("quantiteproduit")]
    public int Quantiteproduit { get; set; }   
    
    
    
    //relations avec les autres tables 
    
    public Accessoire? Accessoires { get; set; }
    
    //relation avec la table Marque
    
    public int IdMarque { get; set; }
    [ForeignKey(nameof(IdMarque))]
    public Marque Marque { get; set; }
    
    
    //relation avec la table Rapport inspection
    ICollection<RapportInspection> RapportInspections { get; set; } = new List<RapportInspection>();
}