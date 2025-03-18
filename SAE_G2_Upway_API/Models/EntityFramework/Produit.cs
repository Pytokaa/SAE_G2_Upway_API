


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace SAE_G2_Upway_API.Models.EntityFramework;





[Table("t_e_produit_pdt")]
public partial class Produit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("pdt_id")]
    
    public int Idproduit { get; set; }

    [Column("pto_id")]
    public int IdPhoto { get; set; }

    [Column("mrq_id")]
    public int IdMarque { get; set; }

    [Column("pdt_nom")]
    [StringLength(100)]
    public string NomProduit { get; set; }

    [Column("pdt_prix")]
    public double PrixProduit { get; set; }

    [Column("pdt_stock")]
    public int StockProduit { get; set; }

    [Column("pdt_description")]
    [StringLength(200)]
    public string DescriptionProduit { get; set; }

    
    //relation avec la table photo
    [ForeignKey(nameof(IdPhoto))]
    [InverseProperty(nameof(Photo.Produit))]
    public virtual Photo Photo { get; set; } = null!;

    //relation avec la table Marque
    
    [ForeignKey(nameof(IdMarque))]
    [InverseProperty(nameof(Marque.Produits))]
    public virtual Marque Marque { get; set; } = null!;

    //relations avec les autres tables 
    [InverseProperty(nameof(Accessoire.Produit))]
  
    public virtual Accessoire? Accessoire { get; set; }

    
    
    [InverseProperty(nameof(Velo.Produit))]
    public virtual Velo? Velo { get; set; }

    //relation avec la table est en favoris, un produit peut etre dans plusieurs liste de favoris

    [InverseProperty(nameof(Est_En_Favoris.LesProduits))]

    public virtual ICollection<Est_En_Favoris> DansLesFavoris { get; set; } = new List<Est_En_Favoris>();

    

    //relation avec la table A_pour_photo
    [InverseProperty(nameof(A_Pour_Photo.ProduitAPhoto))]
   
    public virtual ICollection<A_Pour_Photo> APhotos { get; set; } = new List<A_Pour_Photo>();

    public Produit()
    {
    }
}

