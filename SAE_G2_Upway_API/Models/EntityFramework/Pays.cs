using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("pays")]
public partial class Pays
{
    [Key]
    [Column("idpays", TypeName = "integer")]
    public int IdPays { get; set; }
    
    [Column("nompays")]
    [StringLength(50)]
    public string NomPays { get; set; }
    
    
    //relations avec les adresses
    public virtual ICollection<Adresse> Adresses { get; set; } = new List<Adresse>();
}