using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_G2_Upway_API.Models.EntityFramework;


[Table("t_e_alerte_alt")]
public partial class Alerte
{
    [Key]
    [Column("alt_id")]
    public int IdAlerte { get; set; }
    
    [Column("clt_id")]
    public int IdClient { get; set; }
    
    [Column("tle_id")]
    public int IdTaille { get; set; }
    
    [Column("alt_budgetmax")]
    public int Budgetmax { get; set; }
    
    [Column("alt_email")]
    [StringLength(50)]
    public string Email { get; set; }
    
    
    //relation avec la table client
    [ForeignKey(nameof(IdClient))]
    public virtual Client? Client { get; set; }
    
    
    //relation avec la table taille
    [ForeignKey(nameof(IdTaille))]
    public virtual Taille Taille { get; set; } = null!;
    
    
    
    //relation avec la table Concerne
    [InverseProperty(nameof(Concerne.ConcerneAlerte))]
    public virtual ICollection<Concerne> EstConcerneCategorie { get; set; } =  new List<Concerne>();
}