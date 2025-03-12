using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("contient")]
public partial class Contient
{
    [Key]
    [Column("idcontient")]
    public int IdContient { get; set; }
    [Column("idsoustype")]
    public int IdSoustype { get; set; }
    [Column("idtype")]
    public int IdType { get; set; }
    
    //relation avec la table SousType
    
    [ForeignKey(nameof(IdSoustype))]
    [InverseProperty(nameof(SousType.AType))]
    public virtual SousType ContientSousType { get; set; } = null!;
    
    //relation avec la table Type
    
    [ForeignKey(nameof(IdType))]
    [InverseProperty(nameof(Type.ASousTypes))]
    public virtual Type ContientType { get; set; } = null!;
    
     
}