using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("categorievelo")]
public class CategorieVelo
{
    [Key]
    [Column("idcat")]
    public int IdCat { get; set; }
    
    [Column("nomcat")]
    [StringLength(50)]
    public string NomCategorie { get; set; }
}