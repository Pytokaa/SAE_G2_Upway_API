using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;

[Table("t_e_categorievelo_catv")]
public partial class CategorieVelo
{
    [Key]
    [Column("catv_id")]
    public int IdCat { get; set; }
    
    [Column("catv_nom")]
    [StringLength(50)]
    public virtual string NomCategorie { get; set; }
    
    //relation avec la table velo
    public virtual ICollection<Velo> Velos { get; set; } = new List<Velo>();
    
    //relation avec la table conccerne
    [InverseProperty(nameof(Concerne.ConcerneCategorieVelo))]
    public virtual ICollection<Concerne> ConcerneAlerte { get; set; } =  new List<Concerne>();
    
    
}