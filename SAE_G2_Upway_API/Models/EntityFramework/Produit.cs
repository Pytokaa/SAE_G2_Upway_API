


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
    
    //relation avec la table photo
    public int IdPhoto  { get; set; }
    [ForeignKey(nameof(IdPhoto))]
    public Photo Photo { get; set; }
    
    
    [Column("nomproduit")]
    [StringLength(100)]
    public string Nomproduit { get; set; }
    
    
    [Column("prixproduit")]
    public double Prixproduit { get; set; }
    
    [Column("description")]
    [StringLength(200)]
    public string Descriptionproduit { get; set; }
    
    [Column("stock")]
    public int Stockproduit { get; set; }   
    
    
    
    //relations avec les autres tables 
    
    public Accessoire? Accessoires { get; set; }
    public Velo? Velos { get; set; }

    //relation avec la table est en favoris, un produit peut etre dans plusieurs liste de favoris

    [InverseProperty(nameof(Est_En_Favoris.LesProduits))]
    public virtual ICollection<Est_En_Favoris> DansLesFavoris { get; set; } = new List<Est_En_Favoris>();

    //relation avec la table Marque

    public int IdMarque { get; set; }
    [ForeignKey(nameof(IdMarque))]
    public Marque Marque { get; set; }

    //relation avec la table A_pour_photo
    [InverseProperty(nameof(A_Pour_Photo.ProduitAPhoto))]
    public virtual ICollection<A_Pour_Photo> APhotos { get; set; } = new List<A_Pour_Photo>();
}