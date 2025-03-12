using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("categorieaccessoire")]
public partial class CategorieAccessoire
{
    [Key]
    [Column("idcata")]
    public int IdCatA { get; set; }
    
    [Column("nomcata")]
    [StringLength(30)]
    public string NomCatA { get; set; }
    
    //relation avec la table Accessoire
    public virtual ICollection<Accessoire> Accessoires { get; set; } = new List<Accessoire>();
}