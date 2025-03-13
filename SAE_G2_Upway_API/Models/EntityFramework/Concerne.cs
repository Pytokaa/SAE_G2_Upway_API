using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_j_concerne_crn")]
public partial class Concerne
{
    [Key]
    [Column("crn_id")]
    public int IdConcerne { get; set; }
    [Column("alt_id")]
    public int? IdAlerte { get; set; }
    [Column("catv_id")]
    public int IdCat { get; set; }
    
    //relation avec la table alerte
    [ForeignKey(nameof(IdAlerte))]
    [InverseProperty(nameof(Alerte.EstConcerneCategorie))]
    public virtual Alerte? ConcerneAlerte { get; set; }
    
    
    //relation avec la table categorieVelo
    [ForeignKey(nameof(IdCat))]
    [InverseProperty(nameof(CategorieVelo.ConcerneAlerte))]
    public virtual CategorieVelo ConcerneCategorieVelo { get; set; } = null!;
}