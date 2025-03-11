using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("soustype")]
public partial class SousType
{
    [Key]
    [Column("idsoustype")]
    public int IdSousType { get; set; }
    
    [Column("libellesoustype")]
    [StringLength(30)]
    public string Libellesoustype { get; set; }
    
    ICollection<SurType> surTypes { get; set; } =  new List<SurType>();
}