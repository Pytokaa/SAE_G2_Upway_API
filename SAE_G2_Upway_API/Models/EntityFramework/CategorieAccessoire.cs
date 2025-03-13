using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_categorieaccessoire_cata")]
public partial class CategorieAccessoire
{
    [Key]
    [Column("cata_id")]
    public int IdCatA { get; set; }
    
    [Column("cata_nom")]
    [StringLength(30)]
    public string NomCatA { get; set; }
    
    //relation avec la table Accessoire
    public virtual ICollection<Accessoire> Accessoires { get; set; } = new List<Accessoire>();
}