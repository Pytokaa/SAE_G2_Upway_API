using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("soustype")]
public partial class SousType
{
    //Colonnes
    [Key]
    [Column("idsoustype", TypeName = "integer")]
    public int IdSousType { get; set; }
    
    [Column("libellesoustype")]
    [StringLength(30)]
    public string LibelleSousType { get; set; }


    //relation avec la table SurType
    [InverseProperty(nameof(SurType.LeSousType))]
    public virtual ICollection<SurType> LesSurTypes { get; set; } =  new List<SurType>();
    
    //relation avec la table 
    [InverseProperty(nameof(Contient.ContientSousType))]
    public virtual ICollection<Contient> AType { get; set; } =  new List<Contient>();
}