using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_photo_pto")]
public partial class Photo
{
    [Key]
    [Column("pto_id")]
    public int IdPhoto { get; set; }
    
    [Column("pto_url")]
    [StringLength(300)]
    public string Url { get; set; }
    
    [Column("pto_description")]
    [StringLength(200)]
    public string Description { get; set; }

    //relation avec la table produit
    [InverseProperty(nameof(Produit.Photo))]
    public virtual Produit Produit { get; set; } = null!;
    
    //relation avec la table a_pour_photo
    [InverseProperty(nameof(A_Pour_Photo.Photo))]
    public virtual A_Pour_Photo AProduit { get; set; } = null!;
}