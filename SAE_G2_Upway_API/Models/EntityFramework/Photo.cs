using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("photo")]
public partial class Photo
{
    [Key]
    [Column("idphoto")]
    public int IdPhoto { get; set; }
    
    [Column("url")]
    [StringLength(300)]
    public string Url { get; set; }
    
    [Column("description")]
    [StringLength(200)]
    public string Description { get; set; }
    
    //relation avec la table produit
    public virtual Produit Produit { get; set; } = null!;
    
    //relation avec la table a_pour_photo
    [InverseProperty(nameof(A_Pour_Photo.Photo))]
    public virtual A_Pour_Photo AProduit { get; set; } = null!;
}