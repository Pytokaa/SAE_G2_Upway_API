using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("concerne")]
public partial class Concerne
{
    [Key]
    [Column("idconcerne")]
    public int IdConcerne { get; set; }
    [Column("idalerte")]
    public int IdAlerte { get; set; }
    [Column("idcat")]
    public int IdCat { get; set; }
    
    //relation avec la table alerte
    [ForeignKey(nameof(IdAlerte))]
    [InverseProperty(nameof(Alerte.EstConcerneCategorie))]
    public virtual Alerte ConcerneAlerte { get; set; } = null!;
    
    
    //relation avec la table categorieVelo
    [ForeignKey(nameof(IdCat))]
    [InverseProperty(nameof(CategorieVelo.ConcerneAlerte))]
    public virtual CategorieVelo ConcerneCategorieVelo { get; set; } = null!;
}