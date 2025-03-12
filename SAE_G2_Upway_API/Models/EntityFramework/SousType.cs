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
    
    
    //relation avec la table SurType    
    public virtual ICollection<SurType> SurTypes { get; set; } =  new List<SurType>();
    
    //relation avec la table 
    [InverseProperty(nameof(Contient.ContientSousType))]
    public virtual ICollection<Contient> AType { get; set; } =  new List<Contient>();
}