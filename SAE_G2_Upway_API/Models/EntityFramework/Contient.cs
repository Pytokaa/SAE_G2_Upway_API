using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("t_j_contient_ctn")]
public partial class Contient
{
    [Key]
    [Column("ctn_id")]
    public int IdContient { get; set; }
    [Column("styp_id")]
    public int IdSoustype { get; set; }
    [Column("typ_id")]
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