using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("categorievelo")]
public class CategorieVelo
{
    [Key]
    [Column("idcat", TypeName="integer")]
    public int IdCat { get; set; }
    
    [Column("nomcat")]
    [StringLength(50)]
    public virtual string NomCategorie { get; set; }
    
    //relation avec la table velo
    public virtual ICollection<Velo> Velos { get; set; } = new List<Velo>();
    
    //relation avec la table conccerne
    [InverseProperty(nameof(Concerne.ConcerneCategorieVelo))]
    public virtual ICollection<Concerne> ConcerneAlerte { get; set; } =  new List<Concerne>();
    
    
}