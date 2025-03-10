using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("marque")]
public partial class Marque
{
    [Key]
    [Column("idmarque")]
    public int IdMarque { get; set; }
    
    [Column("nommarque")]
    [StringLength(30)]
    public string NomMarque { get; set; }
}