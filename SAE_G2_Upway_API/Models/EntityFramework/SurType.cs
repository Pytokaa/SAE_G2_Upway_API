using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("t_e_surtype_srtyp")]
public partial class SurType
{
    //Colonne
    [Key]
    [Column("srtyp_id")]
    public int IdSurType { get; set; }

    [Column("styp_id")]
    public int IdSousType { get; set; }

    [Column("srtyp_libelle")]
    [StringLength(250)]
    public string LibelleSurType { get; set; }
    
    [Column("srtyp_repare")]
    public bool Repare { get; set; }
    
    [Column("srtyp_checke")]
    public bool Checke { get; set; }

    //relation avec la table SousType
    [ForeignKey(nameof(IdSousType))]
    public virtual SousType LeSousType { get; set; } = null!;
}