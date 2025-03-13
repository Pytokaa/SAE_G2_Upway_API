using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_pays_pays")]
public partial class Pays
{
    [Key]
    [Column("pays_id")]
    public int IdPays { get; set; }
    
    [Column("pays_nom")]
    [StringLength(50)]
    public string NomPays { get; set; }
    
    
    //relations avec les adresses
    public virtual ICollection<Adresse> Adresses { get; set; } = new List<Adresse>();
}