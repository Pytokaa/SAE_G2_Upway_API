using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("surtype")]
public partial class SurType
{
    [Key]
    [Column("idsurtype")]
    public int IdSurtype { get; set; }
    
    [Column("libellesurtype")]
    [StringLength(100)]
    public string Libellesurtype { get; set; }
    
    [Column("repare")]
    public bool Repare { get; set; }
    
    [Column("checke")]
    public bool Checke { get; set; }
}