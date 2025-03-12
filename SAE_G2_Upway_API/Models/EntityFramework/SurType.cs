using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("surtype")]
public partial class SurType
{
    //Colonne
    [Key]
    [Column("idsurtype")]
    public int IdSurType { get; set; }

    [Column("idsoustype")]
    public int IdSousType { get; set; }

    [Column("libellesurtype")]
    [StringLength(100)]
    public string LibelleSurType { get; set; }
    
    [Column("repare")]
    public bool Repare { get; set; }
    
    [Column("checke")]
    public bool Checke { get; set; }

    //relation avec la table SousType
    [ForeignKey(nameof(IdSousType))]
    public virtual SousType LeSousType { get; set; } = null!;
}