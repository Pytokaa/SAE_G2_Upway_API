using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("modele")]
public partial class Modele
{
    [Key]
    [Column("idmodele")]
    public int IdModele { get; set; }
    
    [Column("nomModele")]
    [StringLength(200)]
    public string NomModele { get; set; }
}