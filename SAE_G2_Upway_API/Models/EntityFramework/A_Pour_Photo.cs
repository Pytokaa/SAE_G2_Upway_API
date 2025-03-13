using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("t_j_apourphoto_appto")]
public partial class A_Pour_Photo
{
    [Key]
    [Column("appto_id")]
    public int Idapourphoto { get; set; }
    
    [Column("pto_id")]
    public int IdPhoto { get; set; }
    [Column("pdt_id")]
    public int IdProduit { get; set; }
    
    
    //relation avec la table photo
    [ForeignKey(nameof(IdPhoto))]
    [InverseProperty(nameof(Photo.AProduit))]
    public virtual Photo Photo { get; set; } = null!;
    
    //relation avec la table produit
    [ForeignKey(nameof(IdProduit))]
    [InverseProperty(nameof(Produit.APhotos))]
    public virtual Produit ProduitAPhoto { get; set; } = null!;
}