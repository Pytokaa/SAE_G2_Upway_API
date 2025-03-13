using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_soustype_styp")]
public partial class SousType
{
    //Colonnes
    [Key]
    [Column("styp_id")]
    public int IdSousType { get; set; }
    
    [Column("styp_libelle")]
    [StringLength(30)]
    public string LibelleSousType { get; set; }


    //relation avec la table SurType
    [InverseProperty(nameof(SurType.LeSousType))]
    public virtual ICollection<SurType> LesSurTypes { get; set; } =  new List<SurType>();
    
    //relation avec la table 
    [InverseProperty(nameof(Contient.ContientSousType))]
    public virtual ICollection<Contient> AType { get; set; } =  new List<Contient>();
}